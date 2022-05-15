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
        /// Имя плагина
        /// </summary>
        public static string Name => "Отметка отверстий";

        /// <summary>
        /// Описание плагина
        /// </summary>
        public static string Description => "Запись отметки уровня в параметр Отметка этажа";

        /// <summary>
        /// Картинка к плагину
        /// </summary>
        public static string Picture => "additionally_32x32";

        /// <summary>
        /// Версия плагина
        /// </summary>
        public static string Version => "1.0";

        /// <summary>
        /// Целевые категории для фильтрации семейств
        /// </summary>
        public static List<BuiltInCategory> TargetElementCategory => new ()
        {
            BuiltInCategory.OST_Windows
        };

        /// <summary>
        /// Имя семейств отв. для выбора
        /// </summary>
        public static HashSet<string> FamilyNames => new HashSet<string>()
        {
            "GEN_Отверстие_Круглое_Стена",
            "GEN_Отверстие_Прямоугольное_Стена",
            "GEN_Проем"
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
        /// Параметр для сравнения, который получает свое значение в результате расчета по формулам координатора
        /// </summary>
        public static string SupportParamName => "Отметка";
        
        /// <summary>
        /// Вспомогательный параметр для уровня
        /// </summary>
        public static string SupportParamForCheckElevation => "Возвышение";

        /// <summary>
        /// Вспомогательный параметр для уровня
        /// </summary>
        public static string SupportParamForCheckElevationRound => "ADSK_Размер_Диаметр";

        /// <summary>
        /// Параметр для проверки, является ли элемент круглым
        /// </summary>
        public static string ParameterForCheckShape => "ADSK_Элемент круглый";
    }
}