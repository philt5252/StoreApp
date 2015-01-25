using System.ComponentModel;

namespace StoreApp.Foundation.ViewModels
{
    public interface IViewModelBase : INotifyPropertyChanged
    {
        bool IsDirty { get; }
    }
}