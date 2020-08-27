using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactiveFoliage : MonoBehaviour
{
    public Material[] materials;
    public Transform player;
    Vector3 playerPosition;

   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("writeToMaterial");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator writeToMaterial() {
        while (true) {
            playerPosition = player.transform.position;
            for (int i = 0; i < materials.Length; i++) {
                materials[i].SetVector("_playerPosition", playerPosition);
            }
            yield return null;
        }
    }
}
