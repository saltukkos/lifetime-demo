using System.Collections.Generic;
using System.Diagnostics;
using Autofac;
using Autofac.Builder;
using JetBrains.Annotations;
using Saltukkos.Lifetime.Abstractions;

namespace Saltukkos.Lifetime.AutofacIntegration
{
    public static class RegistrationBuilderExtensions
    {
        //TODO this works only with RegisterType<T>, you need to implement other registrations in case you need it
        [NotNull]
        public static IRegistrationBuilder<TObject, ConcreteReflectionActivatorData, TRegistrationStyle> UseResolveReactors<TObject, TRegistrationStyle>(
            [NotNull] this IRegistrationBuilder<TObject, ConcreteReflectionActivatorData, TRegistrationStyle> builder)
        {
            Debug.Assert(typeof(TObject) != typeof(object));

            builder.OnActivating(args =>
            {
                Debug.Assert(args != null, nameof(args) + " != null");
                var context = args.Context;
                var instance = args.Instance;

                var lifetime = context.Resolve<ILifetime>();
                var resolveReactors = context.Resolve<IReadOnlyList<IResolveReactor<TObject>>>();

                foreach (var reactor in resolveReactors)
                {
                    reactor.OnResolve(instance, lifetime);
                }

            });

            return builder;
        }
    }
}