using System.Windows;
using Microsoft.Practices.Prism.Regions;
using StoreApp.Foundation.Controllers;
using StoreApp.Foundation.Views;
using StoreApp.Foundation.Views.Factories;

namespace StoreApp.Core.Controllers
{
    public class DashboardController : IDashboardController
    {
        private readonly IDashboardViewFactory dashboardViewFactory;
        private readonly IRegionManager regionManager;

        public DashboardController(IDashboardViewFactory dashboardViewFactory,
            IRegionManager regionManager)
        {
            this.dashboardViewFactory = dashboardViewFactory;
            this.regionManager = regionManager;
        }

        public void Show()
        {
            var dashboardView = dashboardViewFactory.Create();

            regionManager.Regions[Regions.MainRegion].Add(dashboardView);
            regionManager.Regions[Regions.MainRegion].Activate(dashboardView);
        }
    }
}