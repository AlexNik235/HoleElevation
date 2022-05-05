namespace HoleElevation.Views
{
    using System.Windows;
    using Abstractions;
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
        }
    }
}