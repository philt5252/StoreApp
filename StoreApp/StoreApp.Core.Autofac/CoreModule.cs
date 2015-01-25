using Autofac;
using StoreApp.Core.Controllers;
using StoreApp.Core.Factories.ViewModels;
using StoreApp.Core.ViewModels;
using StoreApp.Core.ViewModels.MenuItems;
using StoreApp.Foundation.Controllers;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.ViewModels;

namespace StoreApp.Core.Autofac
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<AppController>().As<IAppController>().SingleInstance();

            builder.RegisterType<MainWindowViewModelFactory>().As<IMainWindowViewModelFactory>().SingleInstance();
            builder.RegisterType<MenuViewModelFactory>().As<IMenuViewModelFactory>().SingleInstance();

            builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>();
            builder.RegisterType<MenuViewModel>().As<IMenuViewModel>();
            builder.RegisterType<BookMenuItemViewModel>().As<IMenuItemViewModel>();
            builder.RegisterType<GameMenuItemViewModel>().As<IMenuItemViewModel>();
            builder.RegisterType<PerformanceMenuItemViewModel>().As<IMenuItemViewModel>();
            builder.RegisterType<EmployeeMenuItemViewModel>().As<IMenuItemViewModel>();
        }
    }
}