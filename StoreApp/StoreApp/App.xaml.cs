using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Autofac;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Regions.Behaviors;
using Microsoft.Practices.ServiceLocation;
using Olf.Prism.Autofac;
using StoreApp.Core.Autofac;
using StoreApp.Core.DataAccess.Autofac;
using StoreApp.Core.Views.Autofac;
using StoreApp.Foundation.Controllers;

namespace StoreApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IContainer container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule<CoreModule>();
            builder.RegisterModule<DataAccessModule>();
            builder.RegisterModule<ViewsModule>();
            builder.RegisterModule<PrismModule>();
            
            container = builder.Build();

            ServiceLocator.SetLocatorProvider(() => container.Resolve<IServiceLocator>());

            ConfigureRegionAdapterMappings();
            ConfigureDefaultRegionBehaviors();

            IAppController appController;

            using (var scope = container.BeginLifetimeScope())
            {
                appController = scope.Resolve<IAppController>();
            }

            appController.Home();
        }

        protected virtual RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var regionAdapterMappings = container.ResolveOptional<RegionAdapterMappings>();

            if (regionAdapterMappings != null)
            {
                regionAdapterMappings.RegisterMapping(typeof (Selector), container.Resolve<SelectorRegionAdapter>());
                regionAdapterMappings.RegisterMapping(typeof (ItemsControl),
                    container.Resolve<ItemsControlRegionAdapter>());
                regionAdapterMappings.RegisterMapping(typeof (ContentControl),
                    container.Resolve<ContentControlRegionAdapter>());
            }

            return regionAdapterMappings;
        }

        private void ConfigureDefaultRegionBehaviors()
        {
            IRegionBehaviorFactory defaultRegionBehaviorTypesDictionary;
            container.TryResolve(out defaultRegionBehaviorTypesDictionary);

            if (defaultRegionBehaviorTypesDictionary != null)
            {
                defaultRegionBehaviorTypesDictionary.AddIfMissing(AutoPopulateRegionBehavior.BehaviorKey,
                    typeof(AutoPopulateRegionBehavior));

                defaultRegionBehaviorTypesDictionary.AddIfMissing(BindRegionContextToDependencyObjectBehavior.BehaviorKey,
                    typeof(BindRegionContextToDependencyObjectBehavior));

                defaultRegionBehaviorTypesDictionary.AddIfMissing(RegionActiveAwareBehavior.BehaviorKey,
                    typeof(RegionActiveAwareBehavior));

                defaultRegionBehaviorTypesDictionary.AddIfMissing(SyncRegionContextWithHostBehavior.BehaviorKey,
                    typeof(SyncRegionContextWithHostBehavior));

                defaultRegionBehaviorTypesDictionary.AddIfMissing(RegionManagerRegistrationBehavior.BehaviorKey,
                    typeof(RegionManagerRegistrationBehavior));

            }
        }
    }
}
