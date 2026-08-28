namespace Infrastructure.States
{
    public class InDialogueState : IGameState
    {
        public bool AllowMovement => false;
        public bool AllowLook => false;
        public bool AllowInteract => false;

        public void Enter() { }
        public void Exit() { }
        public void Tick() { }
    }
}