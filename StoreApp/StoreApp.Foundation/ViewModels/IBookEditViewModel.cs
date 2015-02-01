using System.Drawing;
using System.Windows.Input;
using StoreApp.Foundation.Models;

namespace StoreApp.Foundation.ViewModels
{
    public interface IBookEditViewModel : IViewModelBase
    {
        IBook Book { get; }
        bool IsEdit { get; }
        int Id { get; }
        string Name { get; set; }
        Bitmap Image { get; set; }
        string Description { get; set; }
        double Price { get; set; }
        ICommand SaveCommand { get; }
        ICommand CancelCommand { get; }
        ICommand DeleteCommand { get; }

        ICommand EditCommand { get; }
    }
}