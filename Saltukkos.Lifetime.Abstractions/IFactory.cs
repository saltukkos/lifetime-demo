using JetBrains.Annotations;

namespace Saltukkos.Lifetime.Abstractions
{
    public interface IFactory<out TResult>
    {
        [NotNull]
        TResult Create([NotNull] ILifetime lifetime);
    }
    
    public interface IFactory<in TArgument1, out TResult>
    {
        [NotNull]
        TResult Create([NotNull] ILifetime lifetime, TArgument1 argument1);
    }
    
    public interface IFactory<in TArgument1, in TArgument2, out TResult>
    {
        [NotNull]
        TResult Create([NotNull] ILifetime lifetime, TArgument1 argument1, TArgument2 argument2);
    }
}