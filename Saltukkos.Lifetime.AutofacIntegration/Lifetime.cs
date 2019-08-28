using System;
using Autofac;
using JetBrains.Annotations;
using Saltukkos.Lifetime.Abstractions;

namespace Saltukkos.Lifetime.AutofacIntegration
{
    public class Lifetime : INestedLifetime
    {
        [NotNull]
        private readonly ILifetimeScope _lifetimeScope;

        public Lifetime([NotNull] ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        internal ILifetimeScope UnderlyingScope => _lifetimeScope;

        public INestedLifetime CreateLifetime()
        {
            var nestedScope = _lifetimeScope.BeginLifetimeScope();
            return nestedScope.Resolve<Lifetime>();
        }

        public void AddDisposeAction(Action action)
        {
            // we also can save actions to own stack, but disposer of scope is more convenient
            // because of saving order of components instantiation and action invoking
            var actionWrapper = new DisposableActionWrapper(action);
            _lifetimeScope.Disposer.AddInstanceForDisposal(actionWrapper);
        }

        public void Dispose()
        {
            _lifetimeScope.Dispose();
        }
    }
}