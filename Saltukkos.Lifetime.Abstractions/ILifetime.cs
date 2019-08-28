using System;
using JetBrains.Annotations;

namespace Saltukkos.Lifetime.Abstractions
{
    public interface ILifetime
    {
        [NotNull]
        INestedLifetime CreateLifetime();

        void AddDisposeAction([NotNull] Action action);
    }
}