using System;
using VContainer.Unity;
using Infrastructure.Events;
using Infrastructure.Interfaces;

namespace Mechanics.Scripts
{
    public class ScriptsFacade
    {
        private readonly EventBus _eventBus;

        public ScriptsFacade(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : IEvent
            => _eventBus.Subscribe(handler);

        public void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent : IEvent
            => _eventBus.Unsubscribe(handler);

        public void Publish<TEvent>(TEvent gameEvent) where TEvent : IEvent
            => _eventBus.Publish(gameEvent);
    }
}