using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace StoreApp.Foundation.ViewModels
{
    public abstract class WidgetViewModel : IWidgetViewModel
    {
        public abstract string WidgetName { get; }
        public abstract Bitmap Image { get; }
        public abstract Control CreateWidget();

        public ObservableCollection<object> Errors { get; set; }

        protected abstract IWidgetViewModel CreateWidgetViewModel();
    }
}