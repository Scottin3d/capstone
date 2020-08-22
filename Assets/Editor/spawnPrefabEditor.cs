
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(spawnPrefab))]
public class NewBehaviourScript : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        spawnPrefab script = (spawnPrefab)target;

        if (GUILayout.Button("Generate Prefabs")) {
            script.SpawnPrefab();
        }
    }
}
