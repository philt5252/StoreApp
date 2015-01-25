using System;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.Factories.ViewModels
{
    public class MenuViewModelFactory : IMenuViewModelFactory
    {
        private readonly Func<IMenuItemViewModel[], IMenuViewModel> createViewModelFunc;

        public MenuViewModelFactory(Func<IMenuItemViewModel[], IMenuViewModel> createViewModelFunc )
        {
            this.createViewModelFunc = createViewModelFunc;
        }

        public IMenuViewModel Create(IMenuItemViewModel[] menuItems)
        {
            return createViewModelFunc(menuItems);
        }
    }
}