using System;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.Factories.ViewModels
{
    public class MenuItemViewModelFactory : IMenuItemViewModelFactory
    {
        private readonly Func<IMenuItemViewModel> createViewFunc;

        public MenuItemViewModelFactory(Func<IMenuItemViewModel> createViewFunc)
        {
            this.createViewFunc = createViewFunc;
        }

        public IMenuItemViewModel Create()
        {
            return createViewFunc();
        }
    }
}