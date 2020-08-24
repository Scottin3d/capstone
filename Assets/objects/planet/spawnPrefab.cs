using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPrefab : MonoBehaviour
{
    public Collider[] colliders;

    public int numObjects = 10;

    
    public GameObject prefab;
    private float planetRadius;

    public float minPrefabSize = 1;
    public float maxPrefabSize = 1;

    GameObject rootParent;
    void Start() {
        
    }

    public void SpawnPrefab() {
        planetRadius = GetComponent<SphereCollider>().radius;
        string rootParentName = prefab.name + " root";
        rootParent = new GameObject(rootParentName);
        rootParent.transform.parent = transform;
        SpawnPrefabs();
    }

    private void SpawnPrefabs() {
        //var r = transform.localScale.x / 2;

        for (int i = 0; i < numObjects; i++) {

            Vector3 origin = transform.position;
            Vector3 onPlanet = Random.onUnitSphere * planetRadius;

            float prefabRadius = prefab.GetComponent<CapsuleCollider>().radius;
            colliders = Physics.OverlapSphere(onPlanet, prefabRadius);

            if (colliders.Length > 1) {

                Debug.Log("Collider Hit! Skipping position");
                //i--;
                //continue;
            }
            

            GameObject prefabSpawn = Instantiate(prefab, onPlanet, Quaternion.identity, rootParent.transform) as GameObject;
            prefabSpawn.transform.LookAt(transform.position);
            prefabSpawn.transform.rotation = prefabSpawn.transform.rotation * Quaternion.Euler(-90, 0, 0);
            float rng = Random.Range(minPrefabSize, maxPrefabSize);

            prefabSpawn.transform.localScale *= rng;

        }

    }
}


