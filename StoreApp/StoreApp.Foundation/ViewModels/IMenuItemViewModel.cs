﻿
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace StoreApp.Foundation.ViewModels
{
    public interface IMenuItemViewModel : IViewModelBase
    {
        string Text { get; set; }
        ICommand MenuCommand { get; }
        string NewText { get; }
        BitmapImage Image { get; }

        ObservableCollection<IMenuItemViewModel> SubMenuItems { get; } 
    }


}