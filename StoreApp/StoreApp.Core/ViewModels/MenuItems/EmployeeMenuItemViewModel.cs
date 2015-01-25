using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels.MenuItems
{
    public class EmployeeMenuItemViewModel : IMenuItemViewModel
    {
        public string Text { get { return "Employee"; } }
        public ICommand MenuCommand { get; protected set; }

        public String NewText { get { return "G"; }}

        public EmployeeMenuItemViewModel()
        {
            MenuCommand = new DelegateCommand(ExecuteMenuCommand);
        }

        private void ExecuteMenuCommand()
        {
            throw new NotImplementedException();
        }
    }
}
