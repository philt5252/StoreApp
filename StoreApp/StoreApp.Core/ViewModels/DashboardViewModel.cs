using Microsoft.Practices.Prism.Events;
using StoreApp.Foundation.Events;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.ViewModels
{
    public class DashboardViewModel : IDashboardViewModel
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IMenuItemViewModelFactory menuItemViewModelFactory;

        public DashboardViewModel(IEventAggregator eventAggregator, IMenuItemViewModelFactory menuItemViewModelFactory)
        {
            this.eventAggregator = eventAggregator;
            this.menuItemViewModelFactory = menuItemViewModelFactory;

            var menuItemViewModel = menuItemViewModelFactory.Create();

            menuItemViewModel.Text = "Edit";

            eventAggregator.GetEvent<UpdateSubMenuEvent>().Publish(new []{menuItemViewModel});
        }
    }
}