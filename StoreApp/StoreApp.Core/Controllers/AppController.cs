using System;
using System.Windows.Forms.VisualStyles;
using StoreApp.Foundation.Controllers;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.ViewModels;
using StoreApp.Foundation.Views.Factories;

namespace StoreApp.Core.Controllers
{
    public class AppController : IAppController
    {
        private readonly IMainWindowViewModelFactory mainWindowViewModelFactory;
        private readonly IMainWindowFactory mainMainWindowFactory;

        public AppController(IMainWindowViewModelFactory mainWindowViewModelFactory,
            IMainWindowFactory mainMainWindowFactory)
        {
            this.mainWindowViewModelFactory = mainWindowViewModelFactory;
            this.mainMainWindowFactory = mainMainWindowFactory;
        }

        public void Home()
        {
            var window = mainMainWindowFactory.Create();
            IMainWindowViewModel mainWindowViewModel = mainWindowViewModelFactory.Create();

            window.DataContext = mainWindowViewModel;
            window.Show();
        }
    }
}