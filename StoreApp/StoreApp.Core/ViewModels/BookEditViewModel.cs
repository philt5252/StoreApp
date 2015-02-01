﻿using System;
using System.Drawing;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using StoreApp.Foundation.Controllers;
using StoreApp.Foundation.Models;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels
{
    public class BookEditViewModel : ViewModelBase, IBookEditViewModel
    {
        private readonly IBooksController booksController;
        private int id;
        private string name;
        private double price;
        private string description;
        private Bitmap image;
        private bool isEdit;

        public IBook Book { get; protected set; }

        public bool IsEdit
        {
            get { return isEdit; }
            private set
            {
                isEdit = value;
                OnPropertyChanged();
            }
        }

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
                OnPropertyChanged();
            }
        }

        public Bitmap Image
        {
            get { return image; }
            set
            {
                image = value;

                SetIsDirty();
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;

                SetIsDirty();
                OnPropertyChanged();
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                price = value;

                SetIsDirty();
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; protected set; }
        public ICommand CancelCommand { get; protected set; }

        public ICommand DeleteCommand { get; protected set; }
        public ICommand EditCommand { get; private set; }

        public BookEditViewModel(IBook book, IBooksController booksController)
        {
            Book = book;

            Name = Book.Name;
            Price = Book.Price;
            Id = Book.Id;
            Image = Book.Image;

            this.booksController = booksController;

            SaveCommand = new DelegateCommand(ExecuteSaveCommand);
            CancelCommand = new DelegateCommand(ExecuteCancelCommand);
            DeleteCommand = new DelegateCommand(ExecuteDeleteCommand);
            EditCommand = new DelegateCommand(ExecuteEditCommand);
        }

        private void ExecuteEditCommand()
        {
            IsEdit = !IsEdit;
        }

        private void ExecuteDeleteCommand()
        {
            booksController.Delete(Book);
        }

        protected virtual void ExecuteCancelCommand()
        {
            
        }

        protected virtual void ExecuteSaveCommand()
        {
            Book.Name = Name;
            Book.Price = Price;

            booksController.Save(Book);
        }

        protected virtual void SetIsDirty()
        {
            if (!Book.Name.Equals(Name)
                || !Book.Price.Equals(Price)
                || !Book.Description.Equals(Description)
                || !Book.Image.Equals(Image))
            {
                IsDirty = false;
            }


            IsDirty = true;
        }

       
    }
}