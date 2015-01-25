using System;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.Models;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.Factories.ViewModels
{
    public class BookEditViewModelFactory : IBookEditViewModelFactory
    {
        private readonly Func<IBook, IBookEditViewModel> createViewModelFunc;

        public BookEditViewModelFactory(Func<IBook, IBookEditViewModel> createViewModelFunc )
        {
            this.createViewModelFunc = createViewModelFunc;
        }

        public IBookEditViewModel Create(IBook book)
        {
            return createViewModelFunc(book);
        }
    }
}