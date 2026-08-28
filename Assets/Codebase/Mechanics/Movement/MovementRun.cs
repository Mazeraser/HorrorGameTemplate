using UnityEngine;
using Infrastructure.Interfaces;

namespace Mechanics.Movement
{
    public class MovementRun : IMovement
    {
        private const float Acceleration = 8f;

        private readonly IMovementController _controller;
        private readonly ITimeProvider _timeProvider;
        private readonly float _walkSpeed;
        private readonly float _runSpeed;

        private float _currentSpeed;

        public float Speed => _currentSpeed;

        public MovementRun(float walkSpeed, float runSpeed, IMovementController controller, ITimeProvider timeProvider)
        {
            _walkSpeed = walkSpeed;
            _runSpeed = runSpeed;
            _controller = controller;
            _timeProvider = timeProvider;
            _currentSpeed = walkSpeed;
        }

        public void Move(Vector2 velocity)
        {
            float targetSpeed = velocity.sqrMagnitude > 0.01f ? _runSpeed : _walkSpeed;
            _currentSpeed = Mathf.Lerp(_currentSpeed, targetSpeed, Acceleration * _timeProvider.DeltaTime);

            Vector3 direction = _controller.Transform.right * velocity.x + _controller.Transform.forward * velocity.y;
            direction.y = 0;

            _controller.Move(direction.normalized * _currentSpeed * _timeProvider.DeltaTime);
        }
    }
}