namespace HoleElevation.Models
{
    using System.Collections.Generic;
    using Autodesk.Revit.DB;

    /// <summary>
    /// Настройки плагина
    /// </summary>
    public static class PluginSettings
    {
        /// <summary>
        /// Разделитель между именами семейств
        /// </summary>
        public static char Delimiter => ';';

        /// <summary>
        /// Целевые категории для фильтрации семейств
        /// </summary>
        public static List<BuiltInCategory> TargetElementCategory => new ()
        {
            BuiltInCategory.OST_Windows
        };

        /// <summary>
        /// Параметр для заполнения уровня
        /// </summary>
        public static string LevelParameterName => "Отметка этажа";

        /// <summary>
        /// Параметр для проверки
        /// </summary>
        public static string CheckParameterName => "Высота нижнего бруса";

        /// <summary>
        /// Погрешность
        /// </summary>
        public static double Tolerance => 0.000006;

        /// <summary>
        /// Вспомогательный параметр для расчета
        /// </summary>
        public static string SupportParamName => "Возвышение";
        
        /// <summary>
        /// Вспомогательный параметр для уровня
        /// </summary>
        public static string SupportParamForCheckElevation => "Возвышение";
    }
}