using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Saltukkos.Demo.Application.Messages;
using Saltukkos.Lifetime.Abstractions;

namespace Saltukkos.Demo.Application
{
    public interface IPage
    {

    }

    public class Page : IPage, IMessageSubscriber, IDisposable
    {
        [NotNull]
        [ItemNotNull]
        private readonly IReadOnlyList<ICell> _cells;

        [NotNull]
        private readonly string _name;

        public Page(
            [NotNull] string name,
            [NotNull] ILifetime lifetime,
            [NotNull] IFactory<string, ICell> cellFactory)
        {
            Console.Out.WriteLine($"Page '{name}' created");
            _name = name;
            _cells = Enumerable.Range(0, 5)
                .Select(n => cellFactory.Create(lifetime, $"Cell #{n} from page '{name}'"))
                .ToArray();
        }

        public void OnMessage(string message)
        {
            Console.Out.WriteLine($"Page '{_name}' got message: {message}"); 
            GC.KeepAlive(_cells); //simulate using
        }

        public void Dispose()
        {
            Console.Out.WriteLine($"Page '{_name}' disposed");
        }
    }
}