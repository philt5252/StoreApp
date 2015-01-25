using System;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Practices.Prism.Commands;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels.MenuItems
{
    public class BookMenuItemViewModel : IMenuItemViewModel
    {
        public string Text { get { return "Books"; } }
        public ICommand MenuCommand { get; protected set; }

        public String NewText { get { return "B"; }}
        public BitmapImage Image { get { return new BitmapImage(new Uri("Images/menu.png", UriKind.Relative)); } }

        public BookMenuItemViewModel()
        {
            MenuCommand = new DelegateCommand(ExecuteMenuCommand);
        }

        private void ExecuteMenuCommand()
        {
            throw new NotImplementedException();
        }

    }
}