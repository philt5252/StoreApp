using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
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

        }
    }
}