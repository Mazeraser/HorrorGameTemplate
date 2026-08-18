using UnityEngine;
using Infrastructure.Interfaces;

namespace Mechanics.Movement
{
    public class MovementWalk : IMovement
    {
        private readonly IMovementController _controller;
        private readonly ITimeProvider _timeProvider;
        private readonly float _speed;

        public float Speed => _speed;

        public MovementWalk(float speed, IMovementController controller, ITimeProvider timeProvider)
        {
            _speed = speed;
            _controller = controller;
            _timeProvider = timeProvider;
        }

        public void Move(Vector2 velocity)
        {
            Vector3 direction = _controller.Transform.right * velocity.x + _controller.Transform.forward * velocity.y;
            direction.y = 0;
        
            _controller.Move(direction.normalized * _speed * _timeProvider.DeltaTime);
        }
    }
}