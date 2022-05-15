namespace HoleElevation
{
    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using CSharpFunctionalExtensions;
    using GENPRO_Design.DialogWindow;
    using HoleElevation.Services;
    using LogWindow.Services;
    using Result = Autodesk.Revit.UI.Result;

    /// <summary>
    /// Plugin command
    /// </summary>
    [Regeneration(RegenerationOption.Manual)]
    [Transaction(TransactionMode.Manual)]
    public class Cmd : IExternalCommand
    {
        /*/// <inheritdoc/>
        public override string Name => PluginSettings.Name;

        /// <inheritdoc/>
        public override string Description => PluginSettings.Description;

        /// <inheritdoc/>
        public override string Picture => PluginSettings.Picture;

        /// <inheritdoc/>
        public override string Version => PluginSettings.Version;*/

        /// <inheritdoc/>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var displayLoger = new DisplayLogger(commandData.Application);
            var windowsManageService = new WindowManagerService(commandData.Application, displayLoger);
            return windowsManageService.SetWindowElevation()
                .Match(
                    () =>
                    {
                        if (displayLoger.HasMessages())
                        {
                            displayLoger.Show("Отчет");
                        }

                        return Result.Succeeded;
                    },
                    err =>
                    {
                        GenproWindow.Error(err);
                        return Result.Failed;
                    });
        }
    }
}