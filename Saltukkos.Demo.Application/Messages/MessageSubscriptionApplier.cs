using JetBrains.Annotations;
using Saltukkos.Lifetime.Abstractions;

namespace Saltukkos.Demo.Application.Messages
{
    public class MessageSubscriptionApplier : IResolveReactor<IMessageSubscriber>
    {
        [NotNull]
        private readonly IMessageBroker _broker;

        public MessageSubscriptionApplier([NotNull] IMessageBroker broker)
        {
            _broker = broker;
        }

        public void OnResolve(IMessageSubscriber instance, ILifetime lifetime)
        {
            _broker.RegisterSubscriber(instance);
            lifetime.AddDisposeAction(() => _broker.RemoveSubscriber(instance));
        }
    }
}