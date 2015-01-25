using System.Windows;
using Microsoft.Practices.Prism.Regions;
using StoreApp.Foundation.Controllers;
using StoreApp.Foundation.DataAccess;
using StoreApp.Foundation.Factories.Models;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.Models;
using StoreApp.Foundation.ViewModels;
using StoreApp.Foundation.Views;
using StoreApp.Foundation.Views.Factories;

namespace StoreApp.Core.Controllers
{
    public class BooksController : IBooksController
    {
        private readonly IBooksRepository booksRepository;
        private readonly IBookListingViewModelFactory bookListingViewModelFactory;
        private readonly IBookViewFactory bookViewFactory;
        private readonly IRegionManager regionManager;

        public BooksController(IBooksRepository booksRepository, 
            IBookListingViewModelFactory bookListingViewModelFactory,
            IBookViewFactory bookViewFactory,
            IRegionManager regionManager)
        {
            this.booksRepository = booksRepository;
            this.bookListingViewModelFactory = bookListingViewModelFactory;
            this.bookViewFactory = bookViewFactory;
            this.regionManager = regionManager;
        }

        public void Listing()
        {
            var books = booksRepository.All();

            var bookListingViewModel = bookListingViewModelFactory.Create(books);
            var bookView = bookViewFactory.Create();

            bookView.DataContext = bookListingViewModel;

            regionManager.Regions[Regions.MainRegion].Add(bookView);
            regionManager.Regions[Regions.MainRegion].Activate(bookView);
        }

        public void Save(IBook book)
        {
            booksRepository.Save(book);
        }
    }
}