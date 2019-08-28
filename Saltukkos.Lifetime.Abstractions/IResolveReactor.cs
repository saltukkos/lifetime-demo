using JetBrains.Annotations;

namespace Saltukkos.Lifetime.Abstractions
{
    public interface IResolveReactor<in T>
    {
        void OnResolve([NotNull] T instance, [NotNull] ILifetime lifetime);
    }
}