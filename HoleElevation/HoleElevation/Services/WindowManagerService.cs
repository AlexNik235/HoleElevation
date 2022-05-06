namespace HoleElevation.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using CSharpFunctionalExtensions;
    using Extensions;
    using Models;

    /// <summary>
    /// Сервис по работе с отверстиями
    /// </summary>
    public class WindowManagerService
    {
        private readonly Document _doc;
        private readonly GetElementService _getElementService;
        private readonly Dictionary<string, HashSet<int>> _dictWithProblems = new ();

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="uiDocument">UI document</param>
        public WindowManagerService(UIDocument uiDocument)
        {
            _doc = uiDocument.Document;
            _getElementService = new GetElementService(uiDocument);
        }

        /// <summary>
        /// Устанавливает возвышение для отверстий
        /// </summary>
        /// <param name="familiesStartSymbs">Начальные части имен семейств</param>
        /// <returns>Отчет о работе</returns>
        public Result<string> SetWindowElevation(string familiesStartSymbs)
        {
            return _getElementService.GetWindows(familiesStartSymbs)
                .Bind(SetLevelParameters)
                .Bind(CheckParameters)
                .Map(GenerateMessage);
        }

        private Result<List<Element>> SetLevelParameters(List<Element> elements)
        {
            AddProblem("Всего отверстий найдено для обработки: ", elements.Count);
            var transactionGroup = new TransactionGroup(_doc, "Установка параметров отверстиям");
            transactionGroup.Start();
            var validElements = elements.Where(SetLevelParam).ToList();
            transactionGroup.Assimilate();
            return validElements;
        }

        private bool SetLevelParam(Element element)
        {
            var levelId = element.LevelId;
            if (levelId == ElementId.InvalidElementId || levelId == null)
            {
                AddProblem("Не удалось определить уровень для элеметов: ", element.Id.IntegerValue);
                AddProblem("Элементы пропущены, так как у них возникли ошибки при валидации: ", element.Id.IntegerValue);
                return false;
            }

            var level = (Level)_doc.GetElement(levelId);

            var param = element.GetParameterFromInstanceOrType(PluginSettings.LevelParameterName);
            if (param == null)
            {
                AddProblem(
                    $"Не удалось найти параметр \"{PluginSettings.LevelParameterName}\" для заполнения уровня у элементов: ",
                    element.Id.IntegerValue);
                AddProblem("Элементы пропущены, так как у них возникли ошибки при валидации: ", element.Id.IntegerValue);
                return false;
            }

            var tr = new Transaction(_doc, "1");
            tr.Start();
            if (!param.SetParameterValue(level.Elevation.FtToMm()))
            {
                AddProblem(
                    $"Не удалось заполнить значение параметра \"{PluginSettings.LevelParameterName}\": ",
                    element.Id.IntegerValue);
            }

            tr.Commit();
            return true;
        }

        private CSharpFunctionalExtensions.Result CheckParameters(List<Element> elements)
        {
            elements.ForEach(i =>
            {
                CheckBotPartParamValue(i);
                CheckElevation(i);
            });
            return CSharpFunctionalExtensions.Result.Success();
        }

        private void CheckBotPartParamValue(Element element)
        {
            var param = element.GetParameterFromInstanceOrType(PluginSettings.CheckParameterName);
            if (param == null)
            {
                AddProblem(
                    $"Не удалось найти параметр \"{PluginSettings.CheckParameterName}\" для заполнения уровня у элементов: ",
                    element.Id.IntegerValue);
                AddProblem("Элементы пропущены, так как у них возникли ошибки при валидации: ", element.Id.IntegerValue);
                return;
            }

            if (param.GetParameterValue<double>() > PluginSettings.Tolerance)
            {
                AddProblem(
                    $"Значение параметра \"{PluginSettings.CheckParameterName}\" > 0 у элементов: ",
                    element.Id.IntegerValue);
            }
        }

        private void CheckElevation(Element element)
        {
            var level = (Level)_doc.GetElement(element.LevelId);

            var supportParam = element.GetParameterFromInstanceOrType(PluginSettings.SupportParamName);
            if (supportParam == null)
            {
                AddProblem(
                    $"Не удалось найти параметр \"{PluginSettings.SupportParamName}\": ",
                    element.Id.IntegerValue);
                AddProblem("Элементы пропущены, так как у них возникли ошибки при валидации: ", element.Id.IntegerValue);
                return;
            }

            var checkParameter = element.GetParameterFromInstanceOrType(PluginSettings.SupportParamForCheckElevation);
            if (checkParameter == null)
            {
                AddProblem(
                    $"Не удалось найти параметр \"{PluginSettings.SupportParamForCheckElevation}\": ",
                    element.Id.IntegerValue);
                AddProblem("Элементы пропущены, так как у них возникли ошибки при валидации: ", element.Id.IntegerValue);
                return;
            }

            var difference = Math.Abs(checkParameter.GetParameterValue<double>() -
                                      supportParam.GetParameterValue<double>() - level.Elevation);
            if (difference > PluginSettings.Tolerance)
            {
                AddProblem(
                    "Не прошели проверку на отметку отв, разница между параметром " +
                    $"{PluginSettings.SupportParamForCheckElevation} и {PluginSettings.SupportParamName} " +
                    $"+ отметка уровня различаются: ", element.Id.IntegerValue);
            }
        }

        private void AddProblem(string problem, int id)
        {
            if (_dictWithProblems.ContainsKey(problem))
            {
                _dictWithProblems[problem].Add(id);
            }
            else
            {
                _dictWithProblems.Add(problem, new HashSet<int> { id });
            }
        }

        private string GenerateMessage()
        {
            var sb = new StringBuilder();
            sb.Append("\t\tОтчет по работе плагина:");
            foreach (var problem in _dictWithProblems)
            {
                if (!problem.Value.Any())
                    continue;
                var localSb = new StringBuilder();
                problem.Value.ToList().ForEach(i => localSb.Append($" {i};"));
                sb.Append($"\n\n{problem.Key}\n{localSb}");
            }

            return sb.ToString();
        }
    }
}