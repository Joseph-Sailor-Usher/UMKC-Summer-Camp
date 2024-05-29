using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ZoneTrigger))]
public class ZoneTriggerEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        ZoneTrigger ZoneTrigger = (ZoneTrigger)target;
        if (GUILayout.Button("Test On Condition Met Actions"))
            ZoneTrigger.Trigger();
    }
}
