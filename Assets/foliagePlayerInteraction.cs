using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foliagePlayerInteraction : MonoBehaviour
{

    public float respawnTime = 5f;
    public bool isActive;
    int numMeshes;
    MeshRenderer[] MR;

    private void Start() {
        isActive = true;
        //GetComponent<MeshRenderer>().enabled = isActive;
        numMeshes = transform.childCount;
        MR = new MeshRenderer[numMeshes];
        for (int i = 0; i < numMeshes; i++) {
            MR[i] = transform.GetChild(i).GetComponent<MeshRenderer>();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            if (isActive) {
            
                Debug.Log("Grass");
                for (int i = 0; i < numMeshes; i++) {
                    MR[i].enabled = false;
                }
                isActive = false;
                StartCoroutine(Dissappear());
            }

        }

    }


    IEnumerator Dissappear() {

        yield return new WaitForSeconds(respawnTime);
        for (int i = 0; i < numMeshes; i++) {
            MR[i].enabled = true;
        }
        isActive = true;

    }
}
