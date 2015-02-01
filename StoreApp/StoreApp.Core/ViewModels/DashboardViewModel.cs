using System;
using System.Windows.Media.Imaging;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using StoreApp.Foundation.Events;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels
{
    public class DashboardViewModel : ViewModelBase, IDashboardViewModel
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IMenuItemViewModelFactory menuItemViewModelFactory;
        private bool isEdit;
        private IMenuItemViewModel menuItemViewModel;
        private IMenuItemViewModel itemViewModel;
        private UpdateSubMenuEvent subMenuEvent;

        public bool IsEdit
        {
            get { return isEdit; }
            protected set
            {
                isEdit = value;

                OnPropertyChanged("IsEdit");

                if (!isEdit)
                {
                    subMenuEvent.Publish(new[] { menuItemViewModel });
                }
                else
                {
                    subMenuEvent.Publish(new[] { menuItemViewModel, itemViewModel });
                }
                
            }
        }

        public void RefreshMenuItems()
        {
            if (isEdit)
            {
                subMenuEvent.Publish(new[] { menuItemViewModel, itemViewModel });
            }
            else
            {
                subMenuEvent.Publish(new[] { menuItemViewModel });
            }
        }

        public DashboardViewModel(IEventAggregator eventAggregator, IMenuItemViewModelFactory menuItemViewModelFactory)
        {
            this.eventAggregator = eventAggregator;
            this.menuItemViewModelFactory = menuItemViewModelFactory;

            menuItemViewModel = menuItemViewModelFactory.Create();
            
            menuItemViewModel.Text = "Edit Dashboard";
            menuItemViewModel.SetImage(new BitmapImage(new Uri("Images/home.png", UriKind.Relative)));
            menuItemViewModel.SetMenuCommand(new DelegateCommand(ExecuteMenuCommand));

            itemViewModel = menuItemViewModelFactory.Create();
            itemViewModel.SetImage(new BitmapImage(new Uri("Images/save.png", UriKind.Relative)));

            subMenuEvent = eventAggregator.GetEvent<UpdateSubMenuEvent>();
            subMenuEvent.Publish(new []{menuItemViewModel});
        }

        private void ExecuteMenuCommand()
        {
            IsEdit = !IsEdit;
        }
    }
}