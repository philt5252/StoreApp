using System;
using System.Collections.Generic;
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
    public class GameMenuItemViewModel : MenuItemViewModel
    {
        private readonly IBooksController booksController;
        public override string Text { get { return "Games"; } }
        public override ICommand MenuCommand { get; protected set; }

        public override String NewText { get { return "G"; } }

        public override BitmapImage Image { get { return new BitmapImage(new Uri("Images/menu.png", UriKind.Relative)); } }

        public GameMenuItemViewModel(IEventAggregator eventAggregator, IBooksController booksController)
            :base(eventAggregator)
        {
            this.booksController = booksController;
            MenuCommand = new DelegateCommand(ExecuteMenuCommand);
        }

        private void ExecuteMenuCommand()
        {
            booksController.Listing();
        }
    }
}
