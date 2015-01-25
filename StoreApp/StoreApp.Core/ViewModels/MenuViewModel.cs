using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels
{
    public class MenuViewModel : IMenuViewModel
    {
        public IMenuItemViewModel[] MenuItems { get; private set; }

        public MenuViewModel(IMenuItemViewModel[] menuItems)
        {
            MenuItems = menuItems;
        }
    }
}