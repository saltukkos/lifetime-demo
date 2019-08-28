using Autofac;
using Saltukkos.Lifetime.Abstractions;

namespace Saltukkos.Lifetime.AutofacIntegration
{
    public class Factory<TReturn> : IFactory<TReturn>
    {
        public TReturn Create(ILifetime lifetime)
        {
            var internalLifetime = (Lifetime) lifetime;
            return internalLifetime.UnderlyingScope.Resolve<TReturn>();
        }
    }

    public class Factory<TArgument1, TReturn> : IFactory<TArgument1, TReturn>
    {
        public TReturn Create(ILifetime lifetime, TArgument1 argument1)
        {
            var internalLifetime = (Lifetime) lifetime;
            var parameter1 = new TypedParameter(typeof(TArgument1), argument1);
            return internalLifetime.UnderlyingScope.Resolve<TReturn>(parameter1);
        }
    }

    public class Factory<TArgument1, TArgument2, TReturn> : IFactory<TArgument1, TArgument2, TReturn>
    {
        public TReturn Create(ILifetime lifetime, TArgument1 argument1, TArgument2 argument2)
        {
            var internalLifetime = (Lifetime) lifetime;
            var parameter1 = new TypedParameter(typeof(TArgument1), argument1);
            var parameter2 = new TypedParameter(typeof(TArgument2), argument2);
            return internalLifetime.UnderlyingScope.Resolve<TReturn>(parameter1, parameter2);
        }
    }
}