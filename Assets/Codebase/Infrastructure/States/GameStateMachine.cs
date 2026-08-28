using System;
using System.Collections.Generic;
using VContainer.Unity;
using Infrastructure.Events;

namespace Infrastructure.States
{
    public class GameStateMachine : ITickable
    {
        private readonly EventBus _eventBus;
        private readonly Dictionary<Type, IGameState> _states;
        private IGameState _current;

        public IGameState Current => _current;

        public GameStateMachine(EventBus eventBus)
        {
            _eventBus = eventBus;
            _states = new Dictionary<Type, IGameState>
            {
                { typeof(FreeRoamState), new FreeRoamState() },
                { typeof(InDialogueState), new InDialogueState() },
                { typeof(InCutsceneState), new InCutsceneState() },
                { typeof(ChaseState), new ChaseState() }
            };
            _current = _states[typeof(FreeRoamState)];
        }

        public void ChangeState<TState>() where TState : IGameState
        {
            if (!_states.TryGetValue(typeof(TState), out var next))
                return;

            if (ReferenceEquals(_current, next))
                return;

            var previous = _current;
            _current.Exit();
            _current = next;
            _current.Enter();
            _eventBus.Publish(new GameStateChangedEvent(previous, _current));
        }

        public void Tick()
        {
            _current.Tick();
        }
    }
}