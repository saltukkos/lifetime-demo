using Autofac;
using JetBrains.Annotations;
using Saltukkos.Lifetime.Abstractions;

namespace Saltukkos.Lifetime.AutofacIntegration
{
    public static class ContainerBuilderExtensions
    {
        public static void RegisterLifetimes([NotNull] this ContainerBuilder builder)
        {
            builder.RegisterType<Lifetime>()
                .AsSelf()
                .As<ILifetime>()
                .InstancePerLifetimeScope()
                .ExternallyOwned();

            builder.RegisterGeneric(typeof(Factory<>)).AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(Factory<,>)).AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(Factory<,,>)).AsImplementedInterfaces();
        }
    }
}