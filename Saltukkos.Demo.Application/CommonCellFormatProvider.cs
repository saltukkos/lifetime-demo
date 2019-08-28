using System;
using Saltukkos.Demo.Application.Messages;

namespace Saltukkos.Demo.Application
{
    public interface ICommonCellFormatProvider
    {
    }

    public class CommonCellFormatProvider : ICommonCellFormatProvider, IMessageSubscriber, IDisposable
    {
        public CommonCellFormatProvider()
        {
            Console.Out.WriteLine("CommonCellFormatProvider created");
        }

        public void OnMessage(string message)
        {
            Console.Out.WriteLine($"CommonCellFormatProvider got message {message}");
        }

        public void Dispose()
        {
            Console.Out.WriteLine("CommonCellFormatProvider disposed");
        }
    }
}