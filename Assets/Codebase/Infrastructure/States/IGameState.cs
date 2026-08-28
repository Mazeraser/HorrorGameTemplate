namespace Infrastructure.States
{
    public interface IGameState
    {
        bool AllowMovement { get; }
        bool AllowLook { get; }
        bool AllowInteract { get; }

        void Enter();
        void Exit();
        void Tick();
    }
}