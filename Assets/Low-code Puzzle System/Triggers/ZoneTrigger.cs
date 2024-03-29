using UnityEngine.Events;
using UnityEngine;
using PuzzleSystem;

// Require a box collider
[RequireComponent(typeof(BoxCollider))]
public class ZoneTrigger : MonoBehaviour, ITrigger {
    public UnityEvent onTriggered, onTriggerExit;
    public string triggerObjectTag = "";
    public void Trigger() {
        onTriggered.Invoke();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(triggerObjectTag))
            Trigger();
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag(triggerObjectTag))
            onTriggerExit.Invoke();
    }
}
