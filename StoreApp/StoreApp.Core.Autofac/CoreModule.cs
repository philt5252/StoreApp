using Autofac;
using StoreApp.Core.Controllers;
using StoreApp.Foundation.Controllers;

namespace StoreApp.Core.Autofac
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<AppController>().As<IAppController>().SingleInstance();
        }
    }
}