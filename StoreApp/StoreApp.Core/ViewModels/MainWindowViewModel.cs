using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private IMenuViewModel menuViewModel;
        private ObservableCollection<IMenuItemViewModel> subMenuItems;

        public IMenuItemViewModel[] MenuItems
        {
            get { return menuViewModel.MenuItems; }
        }

        public ObservableCollection<IMenuItemViewModel> SubMenuItems
        {
            get { return subMenuItems; }
            set
            {
                subMenuItems = value; 
                OnPropertyChanged("SubMenuItems");
            }
        }

        public MainWindowViewModel(IEnumerable<IMenuItemViewModel> menuItems, IMenuViewModelFactory menuViewModelFactory)
        {
            menuViewModel = menuViewModelFactory.Create(menuItems.ToArray());

            foreach (var menuItemViewModel in menuViewModel.MenuItems)
            {
                menuItemViewModel.PropertyChanged += MenuItemViewModelOnPropertyChanged;
            }
        }

        private void MenuItemViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "SubMenuItems")
            {
                SubMenuItems = ((IMenuItemViewModel) sender).SubMenuItems;
            }
        }
    }
}