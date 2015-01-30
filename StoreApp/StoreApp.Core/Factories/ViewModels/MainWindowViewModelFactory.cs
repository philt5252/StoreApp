using System;
using System.Collections;
using System.Collections.Generic;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.Factories.ViewModels
{
    public class MainWindowViewModelFactory : IMainWindowViewModelFactory
    {
        private readonly Func<IMainWindowViewModel> createViewModelFunc;

        public MainWindowViewModelFactory(Func<IMainWindowViewModel> createViewModelFunc)
        {
            this.createViewModelFunc = createViewModelFunc;
        }

        public IMainWindowViewModel Create()
        {
            return createViewModelFunc();
        }
    }
}