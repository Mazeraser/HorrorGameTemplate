using Infrastructure.Interfaces;

namespace Infrastructure.States
{
    public readonly struct GameStateChangedEvent : IEvent
    {
        public readonly IGameState From;
        public readonly IGameState To;

        public GameStateChangedEvent(IGameState from, IGameState to)
        {
            From = from;
            To = to;
        }
    }
}