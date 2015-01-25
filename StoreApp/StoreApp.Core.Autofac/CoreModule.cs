using System;
using System.Reflection;
using Autofac;
using StoreApp.Core.Controllers;
using StoreApp.Core.Factories.ViewModels;
using StoreApp.Core.ViewModels;
using StoreApp.Core.ViewModels.MenuItems;
using StoreApp.Foundation.Controllers;
using StoreApp.Foundation.Factories.ViewModels;
using StoreApp.Foundation.ViewModels;
using Module = Autofac.Module;

namespace StoreApp.Core.Autofac
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var path = Environment.CurrentDirectory + "\\StoreApp.Core.dll";
            var coreAssembly = Assembly.LoadFile(path);

            var types = coreAssembly.GetTypes();

            foreach (var type in types)
            {
                if (type.Namespace.Contains("Factories") || type.Namespace.Contains("Controllers"))
                {
                    builder.RegisterType(type).As(type.GetInterfaces()[0]).SingleInstance();
                    continue;
                }

                if (type.Namespace.Contains("ViewModels") || type.Namespace.Contains("Models"))
                {
                    builder.RegisterType(type).As(type.GetInterfaces()[0]);
                }
            }
        }
    }
}