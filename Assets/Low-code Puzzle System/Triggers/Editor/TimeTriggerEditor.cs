using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TimeTrigger))]
public class TimeTriggerEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        TimeTrigger timeTrigger = (TimeTrigger)target;
        // Add a button to turn the time trigger on
        if (GUILayout.Button("Turn On"))
            timeTrigger.SetIsTriggerEnabled(true);
        // Add a button to turn the time trigger off
        if (GUILayout.Button("Turn Off"))
            timeTrigger.SetIsTriggerEnabled(false);
    }
}
