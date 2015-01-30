using System;
using System.Drawing;
using System.Windows;

namespace StoreApp.Foundation.ViewModels
{
    public interface IWidgetViewModel
    {
        string WidgetName { get; }
        Bitmap Image { get; }
        FrameworkElement CreateWidget();
    }
}