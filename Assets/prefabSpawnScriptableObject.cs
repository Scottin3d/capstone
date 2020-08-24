
using UnityEngine;

[CreateAssetMenu(menuName ="Golem/ Prefab Spawn Data")]
public class prefabSpawnScriptableObject : ScriptableObject
{
    [SerializeField]
    private GameObject[] prefabs;

    private int numberOfPrefabs;

    public float boundingSize;

    [Header("Layer Overlap")]
    [Tooltip("Will ignore all Layers and spawned object will have overlap.")]
    public bool ignoreAll = false;
    
    
    public GameObject GetPrefab() {
        numberOfPrefabs = prefabs.Length;

        int rng = Random.Range(0, numberOfPrefabs - 1);
        return prefabs[rng];
    }
}
