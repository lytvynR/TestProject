using System;
using Autofac;

namespace PM.Web.Di
{
    public class RootDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Type[] assemblyIndicators = { typeof(Program) };
            RegisterAssemblyTypes(builder, assemblyIndicators);
        }

        private static void RegisterAssemblyTypes(ContainerBuilder builder, Type[] assemblyIndicators)
        {
            foreach (Type assemblyIndicator in assemblyIndicators)
            {
                builder.RegisterAssemblyTypes(assemblyIndicator.Assembly).AsSelf().AsImplementedInterfaces();
            }
        }
    }
}
