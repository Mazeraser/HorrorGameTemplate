using Infrastructure.Interfaces;
using UnityEngine;

namespace Infrastructure.Unity
{
    public class UnityMovementController : IMovementController
    {
        private readonly CharacterController _controller;
        public Transform Transform => _controller.transform;
    
        public UnityMovementController(CharacterController controller)
        {
            _controller = controller;
        }
    
        public void Move(Vector3 motion) => _controller.Move(motion);
    }
}