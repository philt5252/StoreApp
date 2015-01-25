using System.Windows.Input;

namespace StoreApp.Foundation.ViewModels
{
    public interface IMenuItemViewModel
    {
        string Text { get; }
        ICommand MenuCommand { get; }
    }
}