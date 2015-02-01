using System;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.Factories.ViewModels
{
    public class DashboardViewModelFactory : IDashboardViewModelFactory
    {
        private readonly Func<IDashboardViewModel> createViewModelFunc;

        public DashboardViewModelFactory(Func<IDashboardViewModel> createViewModelFunc )
        {
            this.createViewModelFunc = createViewModelFunc;
        }

        public IDashboardViewModel Create()
        {
            return createViewModelFunc();
        }
    }
}