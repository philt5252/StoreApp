using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using StoreApp.Foundation.Controllers;
using StoreApp.Foundation.Models;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels
{
    public class BookEditViewModel : IBookEditViewModel
    {
        private readonly IBook book;
        private readonly IBooksController booksController;

        public int Id { get; protected set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public ICommand SaveCommand { get; protected set; }
        public ICommand CancelCommand { get; protected set; }

        public BookEditViewModel(IBook book, IBooksController booksController)
        {
            this.book = book;
            this.booksController = booksController;

            SaveCommand = new DelegateCommand(ExecuteSaveCommand);
            CancelCommand = new DelegateCommand(ExecuteCancelCommand);
        }

        private void ExecuteCancelCommand()
        {
            throw new NotImplementedException();
        }

        private void ExecuteSaveCommand()
        {
            book.Name = Name;
            book.Price = Price;

            booksController.Save(book);
        }
    }
}