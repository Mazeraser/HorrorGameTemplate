using Infrastructure.Interfaces;

namespace Mechanics.Movement
{
    public class MovementFactory
    {
        private readonly IMovementController _controller;
        private readonly ITimeProvider _timeProvider;

        public MovementFactory(IMovementController controller, ITimeProvider timeProvider)
        {
            _controller = controller;
            _timeProvider = timeProvider;
        }

        public IMovement CreateWalk(float speed) => new MovementWalk(speed, _controller, _timeProvider);

        public IMovement CreateRun(float walkSpeed, float runSpeed) => new MovementRun(walkSpeed, runSpeed, _controller, _timeProvider);
    }
}