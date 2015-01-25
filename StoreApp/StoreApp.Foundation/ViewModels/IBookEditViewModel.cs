using StoreApp.Foundation.Models;

namespace StoreApp.Foundation.ViewModels
{
    public interface IBookEditViewModel : IViewModelBase
    {
        IBook Book { get; }
    }
}