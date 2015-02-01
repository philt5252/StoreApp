using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Practices.Prism.Events;
using StoreApp.Foundation.Events;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels.MenuItems
{
    public class MenuItemViewModel : ViewModelBase, IMenuItemViewModel
    {
        private readonly IEventAggregator eventAggregator;
        private ObservableCollection<IMenuItemViewModel> subMenuItems;
        public virtual string Text { get; set; }
        public virtual ICommand MenuCommand { get; protected set; }
        public virtual string NewText { get; protected set; }
        public virtual BitmapImage Image { get; protected set; }

        public ObservableCollection<IMenuItemViewModel> SubMenuItems
        {
            get { return subMenuItems; }
            protected set
            {
                subMenuItems = value;

                OnPropertyChanged("SubMenuItems");
            }
        }

        public void SetMenuCommand(ICommand command)
        {
            MenuCommand = command;
        }

        public MenuItemViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            eventAggregator.GetEvent<UpdateSubMenuEvent>().Subscribe(UpdateSubMenuItems);
        }

        private void UpdateSubMenuItems(IMenuItemViewModel[] menuItemViewModels)
        {
            SubMenuItems = new ObservableCollection<IMenuItemViewModel>(menuItemViewModels);
        }
    }
}