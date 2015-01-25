using System;
using System.Net;
using System.Reflection;
using Autofac;
using StoreApp.Core.Views.Views;
using StoreApp.Foundation.Views.Factories;
using Module = Autofac.Module;

namespace StoreApp.Core.Views.Autofac
{
    public class ViewsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var path = Environment.CurrentDirectory + "\\StoreApp.Core.Views.dll";
            var coreAssembly = Assembly.LoadFile(path);

            var types = coreAssembly.GetTypes();

            foreach (var type in types)
            {
                if (type.Namespace.Contains("Factories"))
                {
                    builder.RegisterType(type).As(type.GetInterfaces()[0]).SingleInstance();
                    continue;
                }

                if (type.Namespace.Contains("Views.Views"))
                {
                    builder.RegisterType(type).AsSelf();
                    continue;
                }

                
            }
        }
    }
}