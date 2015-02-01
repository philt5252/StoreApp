﻿using System;
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
            menuItemViewModel.SetImage(new BitmapImage(new Uri("Images/home.png", UriKind.Relative)));
            menuItemViewModel.SetMenuCommand(new DelegateCommand(ExecuteMenuCommand));

            var saveMenuItemViewModel = menuItemViewModelFactory.Create();
            saveMenuItemViewModel.SetImage(new BitmapImage(new Uri("Images/save.png", UriKind.Relative)));

            eventAggregator.GetEvent<UpdateSubMenuEvent>().Publish(new []{menuItemViewModel, saveMenuItemViewModel});
        }

        private void ExecuteMenuCommand()
        {
            IsEdit = !IsEdit;
        }
    }
}