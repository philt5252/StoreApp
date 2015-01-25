using System;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.Models;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.Factories.ViewModels
{
    public class GameListingViewModelFactory :IGameListingViewModelFactory
    {
        private readonly Func<IGame[], IGameListingViewModel> createViewModelFunc;

        public GameListingViewModelFactory(Func<IGame[],IGameListingViewModel> createViewModelFunc)
        {
            this.createViewModelFunc = createViewModelFunc;
        }

        public IGameListingViewModel Create(IGame[] games)
        {
            return createViewModelFunc(games);
        }
    }
}