using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class spawnPrefab : MonoBehaviour {
    public Collider[] colliders;
    public int numObjects = 10;

    public prefabSpawnScriptableObject prefabObject;
    private GameObject prefab;

    private float planetRadius;
    private float prefabRadius;
    private string rootParentName;

    public float minPrefabSize = 1;
    public float maxPrefabSize = 1;

    GameObject rootParent;
    

    public void SpawnPrefab() {

        // set variables
        planetRadius = GetComponent<SphereCollider>().radius;
        prefab = prefabObject.GetPrefab();
        prefabRadius = prefab.GetComponent<CapsuleCollider>().radius;

        // set root object
        rootParentName = prefab.name + " root";
        rootParent = new GameObject(rootParentName);
        rootParent.transform.parent = transform;

        // spawn objects
        SpawnPrefabs();
    }

    private void SetLayerIngore() {
        
    }

    private void SpawnPrefabs() {
        for (int i = 0; i < numObjects; i++) {

            Vector3 origin = transform.position;
            Vector3 onPlanet = Random.onUnitSphere * planetRadius;

            
            colliders = Physics.OverlapSphere(onPlanet, prefabRadius);

            // debug statement
            Debug.Log("spawn vector3: " + onPlanet);
            
            if (colliders.Length > 1 && !prefabObject.ignoreAll) {
                // debug statement
                GameObject testSphere = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere), onPlanet, Quaternion.identity, rootParent.transform) as GameObject;
                testSphere.transform.localScale = new Vector3(1f, 1f, 1f);
                testSphere.GetComponent<MeshRenderer>().sharedMaterial.color = Color.red;
                Debug.Log("Collider Hit! Skipping position");
                //i--;
                //continue;
            } /*else {

                // test code to spawning overlap
                GameObject prefabSpawn = Instantiate(prefab, onPlanet, Quaternion.identity, rootParent.transform) as GameObject;
                prefabSpawn.transform.LookAt(transform.position);
                prefabSpawn.transform.rotation = prefabSpawn.transform.rotation * Quaternion.Euler(-90, 0, 0);
                float rng = Random.Range(minPrefabSize, maxPrefabSize);

                prefabSpawn.transform.localScale *= rng;
            }
            */
        }
    }
}


