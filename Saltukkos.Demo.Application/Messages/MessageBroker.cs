using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Saltukkos.Demo.Application.Messages
{
    public sealed class MessageBroker : IMessageBroker
    {
        [NotNull]
        private readonly object _syncRoot = new object();

        [NotNull]
        [ItemNotNull]
        private readonly HashSet<IMessageSubscriber> _subscribers = new HashSet<IMessageSubscriber>();

        public MessageBroker()
        {
            Task.Run(StartRandomMessageSending);
        }

        public void RegisterSubscriber(IMessageSubscriber subscriber)
        {
            lock (_syncRoot)
            {
                if (!_subscribers.Add(subscriber))
                {
                    throw new InvalidOperationException($"Subscriber {subscriber} is already registered");
                }

                subscriber.OnMessage("Hello, new subscriber!");
            }
        }

        public void RemoveSubscriber(IMessageSubscriber subscriber)
        {
            lock (_syncRoot)
            {
                if (!_subscribers.Remove(subscriber))
                {
                    throw new InvalidOperationException($"Unknown subscriber {subscriber}");
                }

                subscriber.OnMessage("Good bye!");
            }
        }

        private async Task StartRandomMessageSending()
        {
            var random = new Random();
            var messageNumber = 0;

            while (messageNumber < 1000)
            {
                await Task.Delay(5000).ConfigureAwait(false);

                lock (_syncRoot)
                {
                    var count = _subscribers.Count;
                    if (count == 0)
                    {
                        continue;
                    }

                    var subscriber = _subscribers.Skip(random.Next(count) - 1).FirstOrDefault();
                    subscriber?.OnMessage($"Random message {++messageNumber}");
                }
            }
        }
    }
}