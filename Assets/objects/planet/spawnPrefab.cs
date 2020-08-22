using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPrefab : MonoBehaviour
{
    public int numObjects = 10;
    public GameObject prefab;
    private float planetRadius;

    public float minPrefabSize = 1;
    public float maxPrefabSize = 1;
   
    void Start() {
        planetRadius = GetComponent<SphereCollider>().radius;

        SpawnPrefabs();
    }

    private void SpawnPrefabs() {
        //var r = transform.localScale.x / 2;

        for (int i = 0; i < numObjects; i++) {

            Vector3 origin = transform.position;
            Vector3 onPlanet = Random.onUnitSphere * planetRadius;

            GameObject prefabSpawn = Instantiate(prefab, onPlanet, Quaternion.identity) as GameObject;
            prefabSpawn.transform.LookAt(transform.position);
            prefabSpawn.transform.rotation = prefabSpawn.transform.rotation * Quaternion.Euler(-90, 0, 0);
            float rng = Random.Range(minPrefabSize, maxPrefabSize);

            prefabSpawn.transform.localScale = new Vector3(rng, rng , rng);

        }

    }
}


