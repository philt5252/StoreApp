using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StoreApp.Foundation.ViewModels
{
    public interface IBookListingViewModel
    {
        ObservableCollection<IBookEditViewModel> Books { get; }
        ICommand SaveAllCommand { get; }
        ICommand AddCommmand { get; }
    }
}