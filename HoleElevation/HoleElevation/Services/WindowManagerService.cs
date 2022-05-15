namespace HoleElevation.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using CSharpFunctionalExtensions;
    using Extensions;
    using LogWindow.Abstractions;
    using LogWindow.Models;
    using Models;

    /// <summary>
    /// Сервис по работе с отверстиями
    /// </summary>
    public class WindowManagerService
    {
        private readonly Document _doc;
        private readonly IDisplayLogger _displayLoger;
        private readonly GetElementService _getElementService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="uIApplication">UI application</param>
        /// <param name="displayLoger">Логер</param>
        public WindowManagerService(UIApplication uIApplication, IDisplayLogger displayLoger)
        {
            _doc = uIApplication.ActiveUIDocument.Document;
            _getElementService = new GetElementService(uIApplication.ActiveUIDocument);
            _displayLoger = displayLoger;
        }

        /// <summary>
        /// Устанавливает возвышение для отверстий
        /// </summary>
        /// <param name="familiesStartSymbs">Начальные части имен семейств</param>
        /// <returns>Отчет о работе</returns>
        public CSharpFunctionalExtensions.Result SetWindowElevation()
        {
            return _getElementService.GetWindows()
                .Bind(SetLevelParameters)
                .Bind(CheckParameters);
        }

        private Result<List<Element>> SetLevelParameters(List<Element> elements)
        {
            _displayLoger.AddMessage(new InfoMessage($"Всего отверстий найдено для обработки: {elements.Count}"));
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
                _displayLoger.AddMessage(
                    new ErrorMessage(
                        "Не удалось определить уровень для элеметов: ",
                        "Id элементов", 
                        new CommonBaseObjectId(element.Id.IntegerValue)));
                _displayLoger.AddMessage(
                    new ErrorMessage(
                        "Элементы пропущены, так как у них возникли ошибки при валидации: ",
                        "Id элементов",
                        new CommonBaseObjectId(element.Id.IntegerValue)));
                return false;
            }

            var level = (Level)_doc.GetElement(levelId);

            var param = element.GetParameterFromInstanceOrType(PluginSettings.LevelParameterName);
            if (param == null)
            {
                _displayLoger.AddMessage(
                    new ErrorMessage(
                        $"Не удалось найти параметр \"{PluginSettings.LevelParameterName}\" для заполнения уровня у элементов: ",
                        "Id элементов",
                        new CommonBaseObjectId(element.Id.IntegerValue)));

                _displayLoger.AddMessage(
                    new ErrorMessage(
                        "Элементы пропущены, так как у них возникли ошибки при валидации: ",
                        "Id элементов",
                        new CommonBaseObjectId(element.Id.IntegerValue)));
                return false;
            }

            var tr = new Transaction(_doc, "1");
            tr.Start();
            if (!param.SetParameterValue(level.Elevation.FtToMm()))
            {
                _displayLoger.AddMessage(
                    new ErrorMessage(
                        $"Не удалось заполнить значение параметра \"{PluginSettings.LevelParameterName}\": ",
                        "Id элементов",
                        new CommonBaseObjectId(element.Id.IntegerValue)));
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
                _displayLoger.AddMessage(
                    new ErrorMessage(
                        $"Не удалось найти параметр \"{PluginSettings.CheckParameterName}\" для заполнения уровня у элементов: ",
                        "Id элементов",
                        new CommonBaseObjectId(element.Id.IntegerValue)));

                _displayLoger.AddMessage(
                    new ErrorMessage(
                        "Элементы пропущены, так как у них возникли ошибки при валидации: ",
                        "Id элементов",
                        new CommonBaseObjectId(element.Id.IntegerValue)));
                return;
            }

            if (param.GetParameterValue<double>() > PluginSettings.Tolerance)
            {
                _displayLoger.AddMessage(
                    new ErrorMessage(
                        $"Значение параметра \"{PluginSettings.CheckParameterName}\" > 0 у элементов: ",
                        "Id элементов",
                        new CommonBaseObjectId(element.Id.IntegerValue)));
            }
        }

        private void CheckElevation(Element element)
        {
            var level = (Level)_doc.GetElement(element.LevelId);

            var supportParam = element.GetParameterFromInstanceOrType(PluginSettings.SupportParamName);
            if (supportParam == null)
            {
                _displayLoger.AddMessage(
                    new ErrorMessage(
                        $"Не удалось найти параметр \"{PluginSettings.SupportParamName}\": ",
                        "Id элементов",
                        new CommonBaseObjectId(element.Id.IntegerValue)));

                _displayLoger.AddMessage(
                    new ErrorMessage(
                        "Элементы пропущены, так как у них возникли ошибки при валидации: ",
                        "Id элементов",
                        new CommonBaseObjectId(element.Id.IntegerValue)));

                return;
            }

            var windowCheckShapeParam = element.GetParameterFromInstanceOrType(PluginSettings.ParameterForCheckShape);
            if (windowCheckShapeParam == null)
            {
                _displayLoger.AddMessage(
                    new ErrorMessage(
                        $"Не удалось узнать форму отверстия, т.к. отсутствует параметр {PluginSettings.ParameterForCheckShape}",
                        "Id элементов",
                        new CommonBaseObjectId(element.Id.IntegerValue)));

                _displayLoger.AddMessage(
                    new ErrorMessage(
                        "Элементы пропущены, так как у них возникли ошибки при валидации: ",
                        "Id элементов",
                        new CommonBaseObjectId(element.Id.IntegerValue)));

                return;
            }

            var checkParameter = element.GetParameterFromInstanceOrType(PluginSettings.SupportParamForCheckElevation);
            if (checkParameter == null)
            {
                _displayLoger.AddMessage(
                    new ErrorMessage(
                        $"Не удалось найти параметр \"{PluginSettings.SupportParamForCheckElevation}\": ",
                        "Id элементов",
                        new CommonBaseObjectId(element.Id.IntegerValue)));

                _displayLoger.AddMessage(
                    new ErrorMessage(
                        "Элементы пропущены, так как у них возникли ошибки при валидации: ",
                        "Id элементов",
                        new CommonBaseObjectId(element.Id.IntegerValue)));
                return;
            }

            double difference = 0;
            if (windowCheckShapeParam.GetParameterValue<bool>())
            {
                var radiusParam = element.GetParameterFromInstanceOrType(PluginSettings.SupportParamForCheckElevationRound);
                if (checkParameter == null)
                {
                    _displayLoger.AddMessage(
                        new ErrorMessage(
                            $"Не удалось найти параметр \"{PluginSettings.SupportParamForCheckElevation}\": ",
                            "Id элементов",
                            new CommonBaseObjectId(element.Id.IntegerValue)));

                    _displayLoger.AddMessage(
                        new ErrorMessage(
                            "Элементы пропущены, так как у них возникли ошибки при валидации: ",
                            "Id элементов",
                            new CommonBaseObjectId(element.Id.IntegerValue)));
                    return;
                }

                difference = Math.Abs(checkParameter.GetParameterValue<double>()
                                      - supportParam.GetParameterValue<double>()
                                      - level.Elevation
                                      - radiusParam.GetParameterValue<double>());
            }
            else
            {
                difference = Math.Abs(checkParameter.GetParameterValue<double>() -
                                      supportParam.GetParameterValue<double>() - level.Elevation);
            }

            if (difference > PluginSettings.Tolerance)
            {
                _displayLoger.AddMessage(
                    new ErrorMessage(
                        "Не прошели проверку на отметку отв, разница между параметром " +
                    $"{PluginSettings.SupportParamForCheckElevation} и {PluginSettings.SupportParamName} " +
                    $"+ отметка уровня различаются: ",
                        "Id элементов",
                        new CommonBaseObjectId(element.Id.IntegerValue)));
            }
        }
    }
}