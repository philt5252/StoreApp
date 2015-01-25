using System.Collections;
using System.Collections.Generic;
using System.Linq;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private IMenuViewModel menuViewModel;

        public IMenuItemViewModel[] MenuItems
        {
            get { return menuViewModel.MenuItems; }
        }

        public MainWindowViewModel(IEnumerable<IMenuItemViewModel> menuItems, IMenuViewModelFactory menuViewModelFactory)
        {
            menuViewModel = menuViewModelFactory.Create(menuItems.ToArray());
        }
    }
}