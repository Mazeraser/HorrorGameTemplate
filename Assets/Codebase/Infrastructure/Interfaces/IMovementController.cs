using UnityEngine;

namespace Infrastructure.Interfaces
{
    public interface IMovementController
    {
        Transform Transform { get; }
        void Move(Vector3 motion);
    }
}