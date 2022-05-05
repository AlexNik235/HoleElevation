namespace HoleElevation
{
    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using ViewModels;
    using Views;

    /// <summary>
    /// Plugin command
    /// </summary>
    [Regeneration(RegenerationOption.Manual)]
    [Transaction(TransactionMode.Manual)]
    public class Cmd : IExternalCommand
    {
        /// <inheritdoc/>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var mainContext = new MainContext(commandData.Application.ActiveUIDocument);
            var win = new MainWindow(mainContext);
            win.ShowDialog();
            return Result.Succeeded;
        }
    }
}