using System;
using StoreApp.Foundation.Factories.Models;
using StoreApp.Foundation.Models;

namespace StoreApp.Core.Factories.Models
{
    public class BookFactory : IBookFactory
    {
        private readonly Func<IBook> createModelFunc;

        public BookFactory(Func<IBook> createModelFunc )
        {
            this.createModelFunc = createModelFunc;
        }

        public IBook Create()
        {
            return createModelFunc();
        }
    }
}