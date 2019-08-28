using System;

namespace Saltukkos.Lifetime.Abstractions
{
    public interface INestedLifetime : ILifetime, IDisposable
    {
    }
}