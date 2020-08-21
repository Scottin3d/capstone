using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.mainTexture = Instantiate<Texture2D>(GetComponent<Renderer>().material.mainTexture as Texture2D);
    }

    
}
