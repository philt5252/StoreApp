using System.Windows.Input;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels
{
    public class ProductEditViewModel : ViewModelBase, IProductEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
    }
}