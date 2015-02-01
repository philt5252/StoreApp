using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using StoreApp.Core.ViewModels.MenuItems;
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

        public IWidgetViewModel[] Widgets { get; protected set; }

        public MainWindowViewModel(IEnumerable<IMenuItemViewModel> menuItems,
            IEnumerable<IWidgetViewModel> widgets, IMenuViewModelFactory menuViewModelFactory)
        {
            var itemViewModel = menuItems.First(m => m.Text == "Home");
            List<IMenuItemViewModel> list = new List<IMenuItemViewModel>();
            list.Add(itemViewModel);
            foreach (IMenuItemViewModel menuItem in menuItems)
            {
                if (menuItem == itemViewModel)
                {
                    continue;
                }
                list.Add(menuItem);
            }
            menuViewModel = menuViewModelFactory.Create(list.ToArray());
            Widgets = widgets.ToArray();

            foreach (var menuItemViewModel in menuViewModel.MenuItems)
            {
                menuItemViewModel.PropertyChanged += MenuItemViewModelOnPropertyChanged;
            }

            SubMenuItems = new ObservableCollection<IMenuItemViewModel>();
        }

        private void MenuItemViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            IMenuItemViewModel menuItemViewModel = (sender as IMenuItemViewModel);

            if (propertyChangedEventArgs.PropertyName == "SubMenuItems")
            {
                var removeMenuItems = SubMenuItems.Except(menuItemViewModel.SubMenuItems).ToArray();
                var newMenuItems = menuItemViewModel.SubMenuItems.Except(SubMenuItems).ToArray();

                foreach (var removeMenuItem in removeMenuItems)
                {
                    SubMenuItems.Remove(removeMenuItem);
                }

                foreach (var itemViewModel in newMenuItems)
                {
                    SubMenuItems.Add(itemViewModel);
                }
            }
        }
    }
}