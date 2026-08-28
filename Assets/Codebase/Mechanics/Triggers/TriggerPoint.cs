using UnityEngine;
using VContainer;
using Mechanics.Scripts;

namespace Mechanics.Triggers
{
    [RequireComponent(typeof(Collider))]
    public class TriggerPoint : MonoBehaviour
    {
        [SerializeField] private string pointId;
        [SerializeField] private string actorTag = "Player";

        private ScriptsFacade _scriptsFacade;

        [Inject]
        public void Construct(ScriptsFacade scriptsFacade)
        {
            _scriptsFacade = scriptsFacade;
        }

        private void Reset()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(actorTag))
                return;

            Debug.Log("[TriggerPoint] Triggered!");
            _scriptsFacade.Publish(new PointPassedEvent(pointId, other.transform));
        }
    }
}
