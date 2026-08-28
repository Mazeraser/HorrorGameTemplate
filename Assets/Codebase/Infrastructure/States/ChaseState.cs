namespace Infrastructure.States
{
    public class ChaseState : IGameState
    {
        public bool AllowMovement => true;
        public bool AllowLook => true;
        public bool AllowInteract => false;

        public void Enter() { }
        public void Exit() { }
        public void Tick() { }
    }
}