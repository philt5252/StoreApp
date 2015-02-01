﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using StoreApp.Foundation.Controllers;
using StoreApp.Foundation.Events;
using StoreApp.Foundation.Factories.Models;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.Models;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels
{
    public class BookListingViewModel : IBookListingViewModel
    {
        private readonly IBookEditViewModelFactory bookEditViewModelFactory;
        private readonly IBooksController booksController;
        private readonly IBookFactory bookFactory;
        private readonly IEventAggregator eventAggregator;
        private readonly IMenuItemViewModelFactory menuItemViewModelFactory;
        private IMenuItemViewModel editMenuItemViewModel;
        public ObservableCollection<IBookEditViewModel> Books { get; protected set; }

        public ICommand SaveAllCommand { get; protected set; }
        public ICommand AddCommmand { get; protected set; }

        public BookListingViewModel(IBook[] books, IBookEditViewModelFactory bookEditViewModelFactory,
            IBooksController booksController, IBookFactory bookFactory, IEventAggregator eventAggregator,
            IMenuItemViewModelFactory menuItemViewModelFactory)
        {
            this.bookEditViewModelFactory = bookEditViewModelFactory;
            this.booksController = booksController;
            this.bookFactory = bookFactory;
            this.eventAggregator = eventAggregator;
            this.menuItemViewModelFactory = menuItemViewModelFactory;

            var updateSubMenuEvent = eventAggregator.GetEvent<UpdateSubMenuEvent>();
            editMenuItemViewModel = menuItemViewModelFactory.Create();

            editMenuItemViewModel.Text = "Edit";
            editMenuItemViewModel.SetImage(new BitmapImage(new Uri("Images/Edit.png", UriKind.Relative)));

            var saveAllMenuItemViewModel = menuItemViewModelFactory.Create();
            saveAllMenuItemViewModel.Text = "Save All";
            saveAllMenuItemViewModel.SetImage(new BitmapImage(new Uri("Images/Edit.png", UriKind.Relative)));

            updateSubMenuEvent.Publish(new []{editMenuItemViewModel});

            Books = new ObservableCollection<IBookEditViewModel>(books.Select(bookEditViewModelFactory.Create));
            Books.CollectionChanged+= BooksOnCollectionChanged;

            foreach (var bookEditViewModel in Books)
            {
                bookEditViewModel.Deleted += BookEditViewModelOnDeleted;
            }

            SaveAllCommand = new DelegateCommand(ExecuteSaveAllCommand);
            AddCommmand = new DelegateCommand(ExecuteAddCommand);
        }

        private void BookEditViewModelOnDeleted(object sender, EventArgs eventArgs)
        {
            var bookEditViewModel = (sender as IBookEditViewModel);

            Books.Remove(bookEditViewModel);
        }

        private void BooksOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            foreach (IBookEditViewModel book in args.NewItems)
            {
                book.Deleted += BookEditViewModelOnDeleted;
            }

            foreach (IBookEditViewModel book in args.OldItems)
            {
                book.Deleted -= BookEditViewModelOnDeleted;
            }
        }

        private void ExecuteAddCommand()
        {
            var book = bookFactory.Create();
            var bookEditViewModel = bookEditViewModelFactory.Create(book);

            Books.Insert(0, bookEditViewModel);
        }

        private void ExecuteSaveAllCommand()
        {
            foreach (var bookEditViewModel in Books.Where(b => b.IsDirty))
            {
                booksController.Save(bookEditViewModel.Book);
            }
        }
    }
}