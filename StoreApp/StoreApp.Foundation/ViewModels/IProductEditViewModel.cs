using System.ComponentModel;
using System.Windows.Input;

namespace StoreApp.Foundation.ViewModels
{
    public interface IProductEditViewModel: INotifyPropertyChanged
    {
        int Id { get; set; }
        string Name { get; set; }
        double Price { get; set; }

        ICommand SaveCommand { get; set; }
        ICommand CancelCommand { get; set; }
    }
}