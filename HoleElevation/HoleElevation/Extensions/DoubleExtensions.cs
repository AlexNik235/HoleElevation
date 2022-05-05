namespace HoleElevation.Extensions
{
    using Autodesk.Revit.DB;

    /// <summary>
    /// Расширения для Double
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// Футы в мм
        /// </summary>
        /// <param name="fts">Футы</param>
        /// <returns>Мм</returns>
        public static double FtToMm(this double fts)
        {
            return UnitUtils.ConvertFromInternalUnits(fts, DisplayUnitType.DUT_MILLIMETERS);
        }

        /// <summary>
        /// Мм в футы
        /// </summary>
        /// <param name="mm">Мм</param>
        /// <returns>Футы</returns>
        public static double MmToFt(this double mm)
        {
            return UnitUtils.ConvertToInternalUnits(mm, DisplayUnitType.DUT_MILLIMETERS);
        }
    }
}