using StoreApp.Foundation.DataAccess;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.Models;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.Controllers
{
    public class GamesController
    {
        private readonly IGamesRepository gamesRepository;
        private readonly IGameListingViewModelFactory gameListingViewModelFactory;

        public GamesController(IGamesRepository gamesRepository,
            IGameListingViewModelFactory gameListingViewModelFactory)
        {
            this.gamesRepository = gamesRepository;
            this.gameListingViewModelFactory = gameListingViewModelFactory;
        }

        public void Listing()
        {
            var games = gamesRepository.All();
            var gameListingViewModel = gameListingViewModelFactory.Create(games);
        }
    }
}