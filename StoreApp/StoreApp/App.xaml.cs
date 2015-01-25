using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Autofac;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule<CoreModule>();
            builder.RegisterModule<DataAccessModule>();
            builder.RegisterModule<ViewsModule>();

            var container = builder.Build();

            IAppController appController;

            using (var scope = container.BeginLifetimeScope())
            {
                appController = scope.Resolve<IAppController>();
            }

            appController.Home();
        }
    }
}
