using System;
using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace StoreApp.Core.DataAccess.Autofac
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var path = Environment.CurrentDirectory + "\\StoreApp.Core.DataAccess.dll";
            var coreAssembly = Assembly.LoadFile(path);

            var types = coreAssembly.GetTypes();

            foreach (var type in types)
            {
                builder.RegisterType(type).As(type.GetInterfaces()[0]).SingleInstance();
            }
        }
    }
}