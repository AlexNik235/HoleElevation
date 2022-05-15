﻿namespace LogWindow.Views
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Interop;
    using LogWindow.Abstractions;
    using ViewModels;

    /// <inheritdoc />
    public partial class LoggerWindowView : IHidable
    {
        private const int GwlStyle = -16;
        private const int WsMaximizeBox = 0x10000;

        /// <inheritdoc />
        public LoggerWindowView(LoggerWindowViewModel loggerWindowViewModel)
        {
            InitializeComponent();
            DataContext = loggerWindowViewModel;
        }

        /// <inheritdoc />
        protected override void OnSourceInitialized(EventArgs e)
        {
            DisableMinimizeButton();
        }

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

        private void DisableMinimizeButton()
        {
            var windowHandle = new WindowInteropHelper(this).Handle;
            SetWindowLong(windowHandle, GwlStyle, GetWindowLong(windowHandle, GwlStyle) & ~WsMaximizeBox);
        }
    }
}
