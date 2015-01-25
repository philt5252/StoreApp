using System;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.Models;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.Factories.ViewModels
{
    public class BookListingViewModelFactory: IBookListingViewModelFactory
    {
        private readonly Func<IBook[], IBookListingViewModel> createViewModelFunc;

        public BookListingViewModelFactory(Func<IBook[], IBookListingViewModel> createViewModelFunc)
        {
            this.createViewModelFunc = createViewModelFunc;
        }

        public IBookListingViewModel Create(IBook[] books)
        {
            return createViewModelFunc(books);
        }
    }
}