using System;
using System.Collections.ObjectModel;
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
        ObservableCollection<Object> Errors { get;  set; }
    }
}