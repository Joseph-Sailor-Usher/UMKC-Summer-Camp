using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TimeTrigger))]
public class TimeTriggerEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        TimeTrigger timeTrigger = (TimeTrigger)target;

        if (GUILayout.Button("Turn On"))
            timeTrigger.SetIsTriggerEnabled(true);

        if (GUILayout.Button("Turn Off"))
            timeTrigger.SetIsTriggerEnabled(false);
    }
}
