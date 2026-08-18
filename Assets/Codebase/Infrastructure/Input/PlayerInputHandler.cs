using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;
using System;

namespace Infrastructure.Input
{
    public class PlayerInputHandler : IDisposable
    {
        public struct PlayerInputData{
            public Vector2 Velocity;
            public bool IsRunning;
            public Vector2 MouseDelta;
            public bool IsPickuping;
            public bool IsThrowing;
            public bool IsUsing;
        }

        private readonly PlayerInputActions _input;

        public PlayerInputHandler()
        {
            _input=new PlayerInputActions();
            _input.Enable();
        }
        internal PlayerInputHandler(PlayerInputActions input)
        {
            _input = input;
            _input.Enable();
        }
        
        public void Dispose()
        {
            _input.Disable();
            _input.Dispose();
        }

        public PlayerInputData GetInputData(){
            return new PlayerInputData
            {
                Velocity=_input.Movement.velocity.ReadValue<Vector2>(),
                IsRunning=_input.Movement.Run.IsPressed(),
                MouseDelta=_input.Actions.Look.ReadValue<Vector2>(),
                IsPickuping=_input.Actions.Pickup.IsPressed(),
                IsThrowing=_input.Actions.Throw.IsPressed(),
                IsUsing=_input.Actions.Use.IsPressed()
            };
        }
    }
}