using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Practices.Prism.Commands;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels.MenuItems
{
    public class PerformanceMenuItemViewModel : IMenuItemViewModel
    {
        public string Text { get { return "Performance"; } }
        public ICommand MenuCommand { get; protected set; }

        public String NewText { get { return "P"; }}
        public BitmapImage Image { get { return new BitmapImage(new Uri("Images/menu.png", UriKind.Relative)); } }

        public PerformanceMenuItemViewModel()
        {
            MenuCommand = new DelegateCommand(ExecuteMenuCommand);
        }

        private void ExecuteMenuCommand()
        {
            throw new NotImplementedException();
        }
    }
}
