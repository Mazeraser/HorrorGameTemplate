using UnityEngine;
using Infrastructure.Input;
using Infrastructure.Time;
using Infrastructure.Unity;
using Mechanics.Movement;

namespace Mechanics.Movement
{
    public class MovementFactory
    {
        private CharacterController _controller;

        public MovementFactory(CharacterController controller)
        {
            _controller = controller;
        }

        public IMovement CreateWalk(float speed) => new MovementWalk(speed, new UnityMovementController(_controller), new UnityTimeProvider());
    }
}