using System;
using JetBrains.Annotations;

namespace Saltukkos.Lifetime.AutofacIntegration
{
    public class DisposableActionWrapper : IDisposable
    {
        [NotNull]
        private readonly Action _action;

        public DisposableActionWrapper([NotNull] Action action)
        {
            _action = action;
        }

        public void Dispose()
        {
            _action.Invoke();
        }
    }
}