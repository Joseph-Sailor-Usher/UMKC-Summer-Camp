using PuzzleSystem;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Condition))]
public class ConditionGroup : MonoBehaviour, ICondition {
    public List<Condition> conditions;
    public bool sequential = false;
    public Condition metaCondition;

    public bool GetCondition() {
        return metaCondition.GetCondition();
    }
    public void SetCondition(bool value) {
        metaCondition.SetCondition(value);
    }

    public void SetConditionFalse() {
        SetCondition(false);
    }

    public void SetConditionTrue() {
        SetCondition(true);
    }

    public void ToggleCondition() {
        SetCondition(!metaCondition.GetCondition());
    }
}
