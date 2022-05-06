namespace HoleElevation.Views
{
    using System.Windows;
    using Abstractions;
    using GENPRO_Design.DialogWindow;
    using MaterialDesignThemes.Wpf;
    using ViewModels;

    public partial class MainWindow : Window, IClosable
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="mainContext">Основной контекст</param>
        public MainWindow(MainContext mainContext)
        {
            InitializeComponent();
            DataContext = mainContext;

            // todo какие то костыли, без них не видит сборку со стилями генпро, так же удалить
            // материал дизайн
            var kostil = StatusType.Warning;
            var kostil2 = BaseTheme.Inherit;
        }
    }
}