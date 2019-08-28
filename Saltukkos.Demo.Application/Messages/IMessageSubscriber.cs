using JetBrains.Annotations;

namespace Saltukkos.Demo.Application.Messages
{
    public interface IMessageSubscriber
    {
        void OnMessage([NotNull] string message);
    }
}