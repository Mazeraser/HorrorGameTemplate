using UnityEngine;

namespace Mechanics.Movement
{
    public interface IMovement
    {
        float Speed{get;}
        void Move(Vector2 velocity);
    }
}
    