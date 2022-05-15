namespace HoleElevation.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using CSharpFunctionalExtensions;
    using Models;
    using Result = CSharpFunctionalExtensions.Result;

    /// <summary>
    /// Сервис получения элементов
    /// </summary>
    public class GetElementService
    {
        private readonly Document _doc;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="uiDocument">UiDocument</param>
        public GetElementService(UIDocument uiDocument)
        {
            _doc = uiDocument.Document;
        }

        /// <summary>
        /// Получает семейства окон по фильтрации
        /// </summary>
        /// <returns>Список окно</returns>
        public Result<List<Element>> GetWindows()
        {
            try
            {
                return new FilteredElementCollector(_doc).WhereElementIsNotElementType()
                    .WherePasses(new ElementMulticategoryFilter(PluginSettings.TargetElementCategory))
                    .OfType<FamilyInstance>()
                    .Where(i => PluginSettings.FamilyNames.Contains(i.Symbol.Family.Name))
                    .Cast<Element>()
                    .ToList();
            }
            catch (Exception e)
            {
                return Result.Failure<List<Element>>(
                    $"При получении окон возникла непредвиденная проблема: {e.Message}");
            }
        }
    }
}