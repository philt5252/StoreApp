using System.Collections.Generic;
using StoreApp.Foundation.DataAccess;
using StoreApp.Foundation.Factories.Models;
using StoreApp.Foundation.Models;

namespace StoreApp.Core.DataAccess
{
    public class GamesRepository : IGamesRepository
    {
        private readonly IGameFactory gameFactory;
        private List<IGame> games = new List<IGame>();

        public GamesRepository(IGameFactory gameFactory)
        {
            this.gameFactory = gameFactory;

            for (int i = 0; i < 20; i++)
            {
                var game = gameFactory.Create();

                game.Id = i;
                game.Name = "Book" + i;
                game.Description = "Description!!!!" + i;
                game.Price = i;

                games.Add(game);
            }
        }

        public IGame[] All()
        {
            return games.ToArray();
        }

        public void Save(IGame book)
        {
            if (!games.Contains(book))
                games.Add(book);
        }

        public void Delete(IGame book)
        {
            games.Remove(book);
        }
    }
}