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

        protected abstract IWidgetViewModel CreateWidgetViewModel();
    }
}