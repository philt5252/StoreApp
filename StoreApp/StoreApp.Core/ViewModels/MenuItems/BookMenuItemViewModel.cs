using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels.MenuItems
{
    public class BookMenuItemViewModel : IMenuItemViewModel
    {
        public string Text { get { return "Books"; } }
        public ICommand MenuCommand { get; protected set; }

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