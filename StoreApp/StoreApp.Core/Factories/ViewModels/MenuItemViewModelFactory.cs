using System;
using StoreApp.Core.ViewModels.MenuItems;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.Factories.ViewModels
{
    public class MenuItemViewModelFactory : IMenuItemViewModelFactory
    {
        private readonly Func<MenuItemViewModel> createViewFunc;

        public MenuItemViewModelFactory(Func<MenuItemViewModel> createViewFunc)
        {
            this.createViewFunc = createViewFunc;
        }

        public IMenuItemViewModel Create()
        {
            return createViewFunc();
        }
    }
}