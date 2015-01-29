using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using StoreApp.Foundation.Controllers;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels.MenuItems
{
    public class BookMenuItemViewModel : MenuItemViewModel, IMenuItemViewModel
    {
        private readonly IBooksController booksController;
        public override string Text { 
            get { return "Books"; }
            set{ }
        }
        public override ICommand MenuCommand { get; protected set; }

        public override String NewText { get { return "B"; } }
        public override BitmapImage Image { get { return new BitmapImage(new Uri("Images/menu.png", UriKind.Relative)); } }

        public BookMenuItemViewModel(IEventAggregator eventAggregator, IBooksController booksController)
            :base(eventAggregator)
        {
            this.booksController = booksController;
            MenuCommand = new DelegateCommand(ExecuteMenuCommand);

            SubMenuItems = new ObservableCollection<IMenuItemViewModel>();
        }

        private void ExecuteMenuCommand()
        {
            booksController.Listing();
        }

    }
}