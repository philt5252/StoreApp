using System.Drawing;
using System.Windows;

namespace StoreApp.Foundation.ViewModels
{
    public abstract class WidgetViewModel : IWidgetViewModel
    {
        public abstract string WidgetName { get; }
        public abstract Bitmap Image { get; }
        public abstract FrameworkElement CreateWidget();

        protected abstract IWidgetViewModel CreateWidgetViewModel();
    }
}