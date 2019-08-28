using JetBrains.Annotations;

namespace Saltukkos.Demo.Application.Messages
{
    public interface IMessageBroker
    {
        void RegisterSubscriber([NotNull] IMessageSubscriber subscriber);
        void RemoveSubscriber([NotNull] IMessageSubscriber subscriber);
    }
}