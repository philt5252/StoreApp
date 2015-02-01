using System;
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

        public bool IsEdit
        {
            get { return isEdit; }
            protected set
            {
                isEdit = value;

                OnPropertyChanged("IsEdit");
            }
        }

        public DashboardViewModel(IEventAggregator eventAggregator, IMenuItemViewModelFactory menuItemViewModelFactory)
        {
            this.eventAggregator = eventAggregator;
            this.menuItemViewModelFactory = menuItemViewModelFactory;

            var menuItemViewModel = menuItemViewModelFactory.Create();
            
            menuItemViewModel.Text = "Edit Dashboard";
            menuItemViewModel.SetMenuCommand(new DelegateCommand(ExecuteMenuCommand)); 

            eventAggregator.GetEvent<UpdateSubMenuEvent>().Publish(new []{menuItemViewModel});
        }

        private void ExecuteMenuCommand()
        {
            IsEdit = !IsEdit;
        }
    }
}