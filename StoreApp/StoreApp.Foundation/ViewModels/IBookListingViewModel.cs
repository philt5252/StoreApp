using System.Collections.ObjectModel;

namespace StoreApp.Foundation.ViewModels
{
    public interface IBookListingViewModel
    {
        ObservableCollection<IBookEditViewModel> Books { get; }
    }
}