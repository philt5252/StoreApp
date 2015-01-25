using StoreApp.Foundation.Models;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Foundation.Factories.ViewModels
{
    public interface IGameEditViewModelFactory
    {
        IGameEditViewModel Create(IGame game);
    }
}