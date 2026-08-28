namespace Infrastructure.States
{
    public class FreeRoamState : IGameState
    {
        public bool AllowMovement => true;
        public bool AllowLook => true;
        public bool AllowInteract => true;

        public void Enter() { }
        public void Exit() { }
        public void Tick() { }
    }
}