using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace StoreApp.Foundation.ViewModels
{
    public interface IWidgetViewModel
    {
        string WidgetName { get; }
        Bitmap Image { get; }
        Control CreateWidget();
    }
}