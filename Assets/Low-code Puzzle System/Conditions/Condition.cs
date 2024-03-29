using UnityEngine.Events;
using PuzzleSystem;
using UnityEngine;

public class Condition : MonoBehaviour, ICondition {
    [SerializeField]
    private bool isMet = false;
    public UnityEvent onBecomesTrue, onStaysTrue, onBecomesFalse, onStaysFalse, onUpdate;
    public bool GetCondition() {
        return isMet;
    }
    public void SetCondition(bool value) {
        onUpdate.Invoke();
        // Condition stays what it is
        if(value == isMet) {
            // If it is true
            if(isMet) {
                onStaysTrue.Invoke();
            } else {
                onStaysFalse.Invoke();
            }
        } else {
            isMet = value;
            if(value) {
                onBecomesTrue.Invoke();
            } else {
                onBecomesFalse.Invoke();
            }
        }
    }
    public void SetConditionTrue() {
        SetCondition(true);
    }
    public void SetConditionFalse() {
        SetCondition(false);
    }
    public void ToggleCondition() {
        SetCondition(!isMet);
    }
}
