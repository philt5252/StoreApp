using StoreApp.Foundation.Models;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Foundation.Factories.ViewModels
{
    public interface IBookEditViewModelFactory
    {
        IBookEditViewModel Create(IBook book);
    }
}