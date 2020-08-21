using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGeneration : MonoBehaviour
{
    //public Texture2D map;
    [SerializeField]
    private Texture2D tex;

    //debug variable
    public Vector2 coords;
    private Dictionary<Vector2, bool> prefabsInScene;

  

    public ColorToPrefab[] colorMappings;

    private void Start()
    {
        prefabsInScene = new Dictionary<Vector2, bool>();

        tex = transform.GetComponent<Renderer>().material.mainTexture as Texture2D;
        coords = new Vector2(tex.width, tex.height);
    }

    private void FixedUpdate()
    {
        GenerateLevel();
    }

    private void GenerateLevel() { 
        
    }
}
