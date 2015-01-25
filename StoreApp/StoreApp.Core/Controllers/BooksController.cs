using Microsoft.Practices.Prism.Regions;
using StoreApp.Foundation.Controllers;
using StoreApp.Foundation.DataAccess;
using StoreApp.Foundation.Factories.Models;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.Models;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.Controllers
{
    public class BooksController : IBooksController
    {
        private readonly IBooksRepository booksRepository;
        private readonly IBookListingViewModelFactory bookListingViewModelFactory;
        private readonly IRegionManager regionManager;

        public BooksController(IBooksRepository booksRepository, 
            IBookListingViewModelFactory bookListingViewModelFactory,
            IRegionManager regionManager)
        {
            this.booksRepository = booksRepository;
            this.bookListingViewModelFactory = bookListingViewModelFactory;
            this.regionManager = regionManager;
        }

        public void Listing()
        {
            var books = booksRepository.All();

            var bookListingViewModel = bookListingViewModelFactory.Create(books);
        }

        public void Save(IBook book)
        {
            booksRepository.Save(book);
        }
    }
}