using StoreApp.Foundation.ViewModels;

namespace StoreApp.Foundation.Factories.ViewModels
{
    public interface IMenuViewModelFactory
    {
        IMenuViewModel Create(IMenuItemViewModel[] menuItems);
    }
}