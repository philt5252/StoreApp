using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using StoreApp.Foundation.Controllers;
using StoreApp.Foundation.Models;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels
{
    public class BookEditViewModel : ViewModelBase, IBookEditViewModel
    {
        private readonly IBook book;
        private readonly IBooksController booksController;
        private int id;
        private string name;
        private double price;

        public int Id
        {
            get { return id; }
            protected set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;

                SetIsDirty();
            }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public ICommand SaveCommand { get; protected set; }
        public ICommand CancelCommand { get; protected set; }

        public BookEditViewModel(IBook book, IBooksController booksController)
        {
            this.book = book;
            this.booksController = booksController;

            SaveCommand = new DelegateCommand(ExecuteSaveCommand);
            CancelCommand = new DelegateCommand(ExecuteCancelCommand);
        }

        protected virtual void ExecuteCancelCommand()
        {
            throw new NotImplementedException();
        }

        protected virtual void ExecuteSaveCommand()
        {
            book.Name = Name;
            book.Price = Price;

            booksController.Save(book);
        }

        protected virtual void SetIsDirty()
        {
            if (!book.Name.Equals(Name)
                || !book.Price.Equals(Price))
            {
                IsDirty = false;
            }


            IsDirty = true;
        }

        public IBook Book { get; private set; }
    }
}