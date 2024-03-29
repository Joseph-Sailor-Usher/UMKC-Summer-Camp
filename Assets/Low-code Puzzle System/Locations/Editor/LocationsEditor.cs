using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Locations))]
public class LocationsEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        Locations locations = (Locations)target;
        if (GUILayout.Button("Pull Locations From Children"))
            locations.PopulateFromChildObjects();
    }
}
