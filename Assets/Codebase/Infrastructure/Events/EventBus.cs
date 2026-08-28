using System;
using System.Collections.Generic;
using Infrastructure.Interfaces;

namespace Infrastructure.Events
{
    public class EventBus
    {
        private readonly Dictionary<Type, Delegate> _subscribers = new();

        public void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : IEvent
        {
            var eventType = typeof(TEvent);

            _subscribers[eventType] = _subscribers.TryGetValue(eventType, out var existing)
                ? Delegate.Combine(existing, handler)
                : handler;
        }

        public void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent : IEvent
        {
            var eventType = typeof(TEvent);

            if (!_subscribers.TryGetValue(eventType, out var existing))
                return;

            var result = Delegate.Remove(existing, handler);

            if (result == null)
                _subscribers.Remove(eventType);
            else
                _subscribers[eventType] = result;
        }

        public void Publish<TEvent>(TEvent gameEvent) where TEvent : IEvent
        {
            if (_subscribers.TryGetValue(typeof(TEvent), out var existing) && existing is Action<TEvent> handler)
                handler.Invoke(gameEvent);
        }
    }
}
