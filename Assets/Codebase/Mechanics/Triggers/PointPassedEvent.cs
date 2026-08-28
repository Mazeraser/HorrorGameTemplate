using UnityEngine;
using Infrastructure.Interfaces;

namespace Mechanics.Triggers
{
    public readonly struct PointPassedEvent : IEvent
    {
        public readonly string PointId;
        public readonly Transform Actor;

        public PointPassedEvent(string pointId, Transform actor)
        {
            PointId = pointId;
            Actor = actor;
        }
    }
}
