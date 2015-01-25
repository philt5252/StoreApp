using System;
using StoreApp.Foundation.Factories.Models;
using StoreApp.Foundation.Models;

namespace StoreApp.Core.Factories.Models
{
    public class GameFactory : IGameFactory
    {
        private readonly Func<IGame> createModelFunc;

        public GameFactory(Func<IGame> createModelFunc)
        {
            this.createModelFunc = createModelFunc;
        }

        public IGame Create()
        {
            return createModelFunc();
        }
    }
}