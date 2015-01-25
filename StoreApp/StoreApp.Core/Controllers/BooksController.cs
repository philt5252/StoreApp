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

        public BooksController(IBooksRepository booksRepository, IBookListingViewModelFactory bookListingViewModelFactory)
        {
            this.booksRepository = booksRepository;
            this.bookListingViewModelFactory = bookListingViewModelFactory;
        }

        public void Listing()
        {
            var books = booksRepository.All();

            var bookListingViewModel = bookListingViewModelFactory.Create(books);
        }
    }
}