using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels
{
    public class ProductViewModel : ViewModelBase, IProductViewModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
    }
}