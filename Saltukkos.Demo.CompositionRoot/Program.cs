using Autofac;
using Autofac.Features.Variance;
using Saltukkos.Demo.Application;
using Saltukkos.Demo.Application.Messages;
using Saltukkos.Lifetime.AutofacIntegration;

namespace Saltukkos.Demo.CompositionRoot
{
    public static class Program
    {
        public static void Main()
        {
            var container = BuildContainer();
            var mainApplication = container.Resolve<MainApplication>();
            mainApplication.Run();
        }

        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterSource(new ContravariantRegistrationSource());
            containerBuilder.RegisterLifetimes();

            containerBuilder.RegisterType<MessageBroker>().AsImplementedInterfaces().SingleInstance().UseResolveReactors();
            containerBuilder.RegisterType<CommonCellFormatProvider>().AsImplementedInterfaces().SingleInstance().UseResolveReactors();
            containerBuilder.RegisterType<MessageSubscriptionApplier>().AsImplementedInterfaces();
            containerBuilder.RegisterType<Cell>().AsImplementedInterfaces().UseResolveReactors();
            containerBuilder.RegisterType<Page>().AsImplementedInterfaces().UseResolveReactors();
            containerBuilder.RegisterType<MainApplication>().AsSelf().UseResolveReactors();
            return containerBuilder.Build();
        }
    }
}
