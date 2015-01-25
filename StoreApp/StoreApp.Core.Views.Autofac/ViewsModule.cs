using Autofac;
using StoreApp.Core.Views.Views;
using StoreApp.Foundation.Views.Factories;

namespace StoreApp.Core.Views.Autofac
{
    public class ViewsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);


            //factories
            builder.RegisterType<MainWindowFactory>().As<IMainWindowFactory>().SingleInstance();

            //views
            builder.RegisterType<MainWindow>().AsSelf();
        }
    }
}