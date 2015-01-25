
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace StoreApp.Foundation.ViewModels
{
    public interface IMenuItemViewModel
    {
        string Text { get; }
        ICommand MenuCommand { get; }
        string NewText { get; }
    }


}