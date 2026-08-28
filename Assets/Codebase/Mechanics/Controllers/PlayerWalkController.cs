using UnityEngine;
using VContainer;
using VContainer.Unity;
using Infrastructure;
using Infrastructure.Input;
using Infrastructure.States;
using Mechanics.Movement;

namespace Mechanics.Controllers
{
    public class PlayerWalkController : IStartable, ITickable
    {
        private readonly PlayerInputHandler _inputHandler;
        private readonly MovementFactory _movementFactory;
        private readonly PlayerConfig _config;
        private readonly PlayerGravity _gravity;
        private readonly GameStateMachine _stateMachine;

        private IMovement _walkMovement;
        private IMovement _runMovement;
        private IMovement _currentMovement;

        public PlayerWalkController(
            PlayerInputHandler inputHandler,
            MovementFactory movementFactory,
            PlayerConfig config,
            PlayerGravity gravity,
            GameStateMachine stateMachine)
        {
            _inputHandler = inputHandler;
            _movementFactory = movementFactory;
            _config = config;
            _gravity = gravity;
            _stateMachine = stateMachine;
        }

        void IStartable.Start()
        {
            _walkMovement = _movementFactory.CreateWalk(_config.WalkSpeed);
            _runMovement = _movementFactory.CreateRun(_config.WalkSpeed, _config.RunSpeed);
            _currentMovement = _walkMovement;
        }

        void ITickable.Tick()
        {
            var inputData = _inputHandler.GetInputData();

            if (_stateMachine.Current.AllowMovement)
            {
                _currentMovement = _config.CanRun && inputData.IsRunning ? _runMovement : _walkMovement;
                ApplyMovement(inputData.Velocity);
            }

            bool wantsJump = _config.CanJump && inputData.IsJumping;
            _gravity.Update(wantsJump, _config.JumpPower);
        }

        private void ApplyMovement(Vector2 velocity)
        {
            _currentMovement.Move(velocity.normalized);
        }
    }
}