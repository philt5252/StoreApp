using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using StoreApp.Core.Views.Views;
using StoreApp.Foundation.Views.Factories;

namespace StoreApp.Core.Views
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
