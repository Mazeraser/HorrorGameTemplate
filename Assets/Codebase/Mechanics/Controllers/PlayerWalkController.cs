using UnityEngine;
using VContainer;
using VContainer.Unity;
using Infrastructure.Input;
using Mechanics.Movement;

namespace Mechanics.Controllers
{
    public class PlayerWalkController : IStartable, ITickable
    {
        private readonly PlayerInputHandler _inputHandler;
        private readonly MovementFactory _movementFactory;
        private readonly PlayerConfig _config;

        private IMovement _currentMovement;

        public PlayerWalkController(PlayerInputHandler inputHandler, MovementFactory movementFactory, PlayerConfig config)
        {
            _inputHandler = inputHandler;
            _movementFactory = movementFactory;
            _config = config;
        }

        void IStartable.Start()
        {
            _currentMovement= _movementFactory.CreateWalk(_config.WalkSpeed);
        }
        void ITickable.Tick()
        {
            var inputData = _inputHandler.GetInputData();

            ApplyMovement(inputData.Velocity);     
        }

        private void ApplyMovement(Vector2 velocity)
        {
            _currentMovement.Move(velocity.normalized);
        }
    }
}