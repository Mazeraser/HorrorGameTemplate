using UnityEngine;
using Infrastructure.Interfaces;

namespace Mechanics.Movement
{
    public class PlayerGravity
    {
        private const float Gravity = -9.82f;
        private const float GroundedStickVelocity = -0.5f;

        private readonly IMovementController _controller;
        private readonly ITimeProvider _timeProvider;

        private float _verticalVelocity;

        public PlayerGravity(IMovementController controller, ITimeProvider timeProvider)
        {
            _controller = controller;
            _timeProvider = timeProvider;
        }

        public void Update(bool wantsJump, float jumpPower)
        {
            if (_controller.IsGrounded)
            {
                if (_verticalVelocity < 0f)
                    _verticalVelocity = GroundedStickVelocity;

                if (wantsJump)
                    _verticalVelocity = jumpPower;
            }

            Debug.Log($"[PlayerGravity] Is grounded: {_controller.IsGrounded}");

            _verticalVelocity += Gravity * _timeProvider.DeltaTime;

            _controller.Move(new Vector3(0f, _verticalVelocity, 0f) * _timeProvider.DeltaTime);
        }
        
        
    }
}