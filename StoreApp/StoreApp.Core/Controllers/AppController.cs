using System;
using System.Windows.Forms.VisualStyles;
using StoreApp.Foundation.Controllers;
using StoreApp.Foundation.Views.Factories;

namespace StoreApp.Core.Controllers
{
    public class AppController : IAppController
    {
        private readonly IMainWindowFactory mainMainWindowFactory;

        public AppController(IMainWindowFactory mainMainWindowFactory)
        {
            this.mainMainWindowFactory = mainMainWindowFactory;
        }

        public void Home()
        {
            var window = mainMainWindowFactory.Create();
            window.Show();
        }
    }
}