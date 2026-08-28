using UnityEngine;
using VContainer.Unity;
using Infrastructure;
using Infrastructure.Input;
using Infrastructure.Interfaces;
using Infrastructure.States;

namespace Mechanics.Controllers
{
    public class PlayerCameraController : ITickable
    {
        private readonly ICameraController _camera;
        private readonly PlayerInputHandler _inputHandler;
        private readonly PlayerConfig _config;
        private readonly IMovementController _playerMovement;
        private readonly ITimeProvider _timeProvider;
        private readonly GameStateMachine _stateMachine;
    
        private float _xRotation = 0f;
        private float _yRotation = 0f;

        public PlayerCameraController(
            ICameraController camera,
            PlayerInputHandler inputHandler,
            PlayerConfig config,
            IMovementController playerMovement,
            ITimeProvider timeProvider,
            GameStateMachine stateMachine)
        {
            _camera = camera;
            _inputHandler = inputHandler;
            _config = config;
            _playerMovement = playerMovement;
            _timeProvider = timeProvider;
            _stateMachine = stateMachine;
        }

        void ITickable.Tick()
        {
            if (!_stateMachine.Current.AllowLook)
                return;

            var inputData = _inputHandler.GetInputData();
            ApplyRotation(inputData.MouseDelta);
        }

        private void ApplyRotation(Vector2 mouseDelta)
        {
            float sensitivity = _config.Sensitivity * 100f;
        
            _yRotation += mouseDelta.x * sensitivity * _timeProvider.DeltaTime;
            _playerMovement.Transform.rotation = Quaternion.Euler(0f, _yRotation, 0f);
        
            _xRotation -= mouseDelta.y * sensitivity * _timeProvider.DeltaTime;
            _xRotation = Mathf.Clamp(_xRotation, -60f, 90f);
        
            _camera.SetLocalRotation(Quaternion.Euler(_xRotation, _yRotation, 0f));
        }
    }
}