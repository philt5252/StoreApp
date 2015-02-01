using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using StoreApp.Foundation.Controllers;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels.MenuItems
{
    public class HomeMenuItemViewModel : MenuItemViewModel
    {
            private readonly IDashboardController dashboardController;
            public override string Text { get { return "Home"; } }
            public override ICommand MenuCommand { get; protected set; }

            public override String NewText { get { return "H"; } }
            public override BitmapImage Image { get { return new BitmapImage(new Uri("Images/home.png", UriKind.Relative)); } }

            public HomeMenuItemViewModel(IEventAggregator eventAggregator, IDashboardController dashboardController)
                : base(eventAggregator)
            {
                this.dashboardController = dashboardController;
                MenuCommand = new DelegateCommand(ExecuteMenuCommand);
            }

            private void ExecuteMenuCommand()
            {
                dashboardController.Show();
            }
        }
    
}
