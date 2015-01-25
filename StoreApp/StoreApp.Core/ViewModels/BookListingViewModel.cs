using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.Models;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels
{
    public class BookListingViewModel : IBookListingViewModel
    {
        public ObservableCollection<IBookEditViewModel> Books { get; protected set; }

        public ICommand SaveAllCommand { get; protected set; }

        public BookListingViewModel(IBook[] books, IBookEditViewModelFactory bookEditViewModelFactory)
        {
            Books = new ObservableCollection<IBookEditViewModel>(books.Select(bookEditViewModelFactory.Create));
            SaveAllCommand = new DelegateCommand(ExecuteSaveAllCommand);
        }

        private void ExecuteSaveAllCommand()
        {
            foreach (var bookEditViewModel in Books.Where(b => b.IsDirty))
            {
                
            }
        }
    }
}