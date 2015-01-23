using StoreApp.Foundation.Models;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Foundation.Factories.ViewModels
{
    public interface IProductEditViewModelFactory
    {
        IProductEditViewModel Create(IProduct product);
    }
}