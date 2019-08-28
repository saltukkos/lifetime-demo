using System;
using JetBrains.Annotations;
using Saltukkos.Demo.Application.Messages;

namespace Saltukkos.Demo.Application
{
    public interface ICell
    {

    }

    public class Cell : ICell, IMessageSubscriber, IDisposable
    {
        [NotNull]
        private readonly string _name;

        public Cell([NotNull] string name, [NotNull] ICommonCellFormatProvider cellFormatProvider)
        {
            _name = name;
            GC.KeepAlive(cellFormatProvider);
        }

        public void OnMessage(string message)
        {
            Console.Out.WriteLine($"Cell '{_name}' got message '{message}'");
        }

        public void Dispose()
        {
            Console.Out.WriteLine($"Cell '{_name}' disposed");
        }
    }
}