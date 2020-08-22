using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPrefab : MonoBehaviour
{
    public int numObjects = 10;
    public GameObject prefab;
    private float planetRadius;
   
    void Start() {
        planetRadius = GetComponent<SphereCollider>().radius;

        SpawnPrefabs();
    }

    private void SpawnPrefabs() {
        //var r = transform.localScale.x / 2;

        for (int i = 0; i < numObjects; i++) {

            Vector3 origin = transform.position;
            Vector3 onPlanet = Random.onUnitSphere * planetRadius;

            GameObject newGO = Instantiate(prefab, onPlanet, Quaternion.identity) as GameObject;
            newGO.transform.LookAt(transform.position);
            newGO.transform.rotation = newGO.transform.rotation * Quaternion.Euler(-90, 0, 0);

        }

    }
}


