using UnityEngine;
using UnityEngine.Events;
using VContainer;
using Mechanics.Triggers;

namespace Mechanics.Scripts
{
    public class PassThroughPointScript : MonoBehaviour, IGameScript
    {
        [SerializeField] private string pointId;
        [SerializeField] private bool oneShot = true;
        [SerializeField] private UnityEvent onPassed;

        private ScriptsFacade _scriptsFacade;
        private bool _triggered;

        [Inject]
        public void Construct(ScriptsFacade scriptsFacade)
        {
            _scriptsFacade = scriptsFacade;
        }

        public void Activate()
        {
            _scriptsFacade.Subscribe<PointPassedEvent>(OnPointPassed);
            Debug.Log("[PassThroughtPointScript] Activated!");
        }

        public void Deactivate()
        {
            _scriptsFacade.Unsubscribe<PointPassedEvent>(OnPointPassed);
            Debug.Log("[PassThroughtPointScript] Deactivated!");
        }

        private void OnPointPassed(PointPassedEvent gameEvent)
        {            
            if (oneShot && _triggered)
                return;

            if (gameEvent.PointId != pointId)
                return;
                
            Debug.Log("[PassThroughtPointScript] Event triggered!");

            _triggered = true;
            onPassed?.Invoke();
        }
    }
}
