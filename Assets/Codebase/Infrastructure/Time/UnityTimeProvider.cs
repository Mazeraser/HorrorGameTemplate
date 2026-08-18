using Infrastructure.Interfaces;
using UnityEngine;

namespace Infrastructure.Time
{
    public class UnityTimeProvider : ITimeProvider
    {
        public float DeltaTime => UnityEngine.Time.deltaTime;
    }
}