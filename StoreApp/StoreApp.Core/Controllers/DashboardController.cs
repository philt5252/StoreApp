﻿using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;
using StoreApp.Foundation.Controllers;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.ViewModels;
using StoreApp.Foundation.Views;
using StoreApp.Foundation.Views.Factories;

namespace StoreApp.Core.Controllers
{
    public class DashboardController : IDashboardController
    {
        private readonly IDashboardViewFactory dashboardViewFactory;
        private readonly IDashboardViewModelFactory dashboardViewModelFactory;
        private readonly IRegionManager regionManager;

        public DashboardController(IDashboardViewFactory dashboardViewFactory,
            IDashboardViewModelFactory dashboardViewModelFactory,
            IRegionManager regionManager)
        {
            this.dashboardViewFactory = dashboardViewFactory;
            this.dashboardViewModelFactory = dashboardViewModelFactory;
            this.regionManager = regionManager;
        }

        public void Show()
        {
            var view = regionManager.Regions[Regions.MainRegion].GetView("dashboardView");

            if (view != null)
            {
                regionManager.Regions[Regions.MainRegion].Activate(view);
                ((view as Control).DataContext as IDashboardViewModel).RefreshMenuItems();
                return;
            }

            var dashboardView = dashboardViewFactory.Create();
            var dashboardViewModel = dashboardViewModelFactory.Create();

            dashboardView.DataContext = dashboardViewModel;

            regionManager.Regions[Regions.MainRegion].Add(dashboardView, "dashboardView");
            regionManager.Regions[Regions.MainRegion].Activate(dashboardView);
        }
    }
}