using UnityEngine;

namespace Infrastructure.Interfaces
{
    public interface ICameraController
    {
        Transform Transform { get; }
        void SetLocalRotation(Quaternion rotation);
    }
}