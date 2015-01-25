using System;
using System.Windows;
using StoreApp.Core.Views.Views;
using StoreApp.Foundation.Views.Factories;

namespace StoreApp.Core.Views.Factories
{
    public class MainWindowFactory : IMainWindowFactory
    {
        private readonly Func<MainWindow> createMainWindow;

        public MainWindowFactory(Func<MainWindow> createMainWindow )
        {
            this.createMainWindow = createMainWindow;
        }

        public Window Create()
        {
            return createMainWindow();
        }
    }
}
