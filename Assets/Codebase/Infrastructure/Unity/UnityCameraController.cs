using UnityEngine;
using Unity.Cinemachine;
using Infrastructure.Interfaces;

namespace Infrastructure.Unity
{
    public class UnityCameraController : ICameraController
    {
        private readonly CinemachineCamera _camera;
        public Transform Transform => _camera.transform;
    
        public UnityCameraController(CinemachineCamera camera)
        {
            _camera = camera;
        }
    
        public void SetLocalRotation(Quaternion rotation)
        {
            _camera.transform.localRotation = rotation;
        }
    }
}