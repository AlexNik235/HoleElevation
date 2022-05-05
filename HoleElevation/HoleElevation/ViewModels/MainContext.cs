namespace HoleElevation.ViewModels
{
    using System;
    using System.Windows.Input;
    using Abstractions;
    using Autodesk.Revit.UI;
    using CSharpFunctionalExtensions;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GENPRO_Design.DialogWindow;
    using Services;

    /// <summary>
    /// Основной контекст
    /// </summary>
    public class MainContext : ObservableObject
    {
        private readonly WindowManagerService _windowManagerService;
        private readonly UserSettingsService _userSettingsService;
        private string _familyStartWithList;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="uiDocument">UIdocument</param>
        public MainContext(UIDocument uiDocument)
        {
            _windowManagerService = new WindowManagerService(uiDocument);
            _userSettingsService = new UserSettingsService();
            FamilyStartWithList = _userSettingsService.Get<string>(nameof(FamilyStartWithList));
        }

        /// <summary>
        /// Строка с перечислением с каких строк начинается семейство
        /// </summary>
        public string FamilyStartWithList
        {
            get => _familyStartWithList;
            set
            {
                _familyStartWithList = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Команда заполнения параметров для отверстий
        /// </summary>
        public ICommand ExecuteCommand => new RelayCommand<IClosable>(Execute);

        private void Execute(IClosable win)
        {
            try
            {
                _windowManagerService.SetWindowElevation(FamilyStartWithList)
                    .OnFailure(err => GenproWindow.Error(err))
                    .Tap(res => GenproWindow.Information(res));
            }
            catch (Exception e)
            {
                GenproWindow.Error($"При выполнении команды возникла непредвиденная ошибка: {e.Message}");
            }
            finally
            {
                _userSettingsService.Set(FamilyStartWithList, nameof(FamilyStartWithList));
                win.Close();
            }
        }
    }
}