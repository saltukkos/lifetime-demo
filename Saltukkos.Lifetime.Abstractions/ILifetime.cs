using JetBrains.Annotations;

namespace Saltukkos.Lifetime.Abstractions
{
    public interface ILifetime
    {
        [NotNull]
        INestedLifetime CreateLifetime();
    }
}