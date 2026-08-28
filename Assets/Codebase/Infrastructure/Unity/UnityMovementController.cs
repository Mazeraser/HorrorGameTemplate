using Infrastructure.Interfaces;
using UnityEngine;

namespace Infrastructure.Unity
{
    public class UnityMovementController : IMovementController
    {
        private readonly CharacterController _controller;
        public Transform Transform => _controller.transform;
        public bool IsGrounded 
        {
            get 
            {
                float extraHeight = 0.1f;
                RaycastHit hit;
                Vector3 origin = _controller.transform.position + _controller.center;
                float distance = _controller.height / 2 + extraHeight;
                
                if (Physics.Raycast(origin, Vector3.down, out hit, distance))
                {
                    return true;
                }
            
                return false;
            }
        }
         
    
        public UnityMovementController(CharacterController controller)
        {
            _controller = controller;
        }
    
        public void Move(Vector3 motion) => _controller.Move(motion);
    }
}