using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private Color[] colors;
    [SerializeField]
    private int effectRadius = 5;

    // change to private later
    // stores coordinates of pixel hits on main texture and stores pixel color
    //public Dictionary<Vector2, Color> spawnObjectCoords;
    public List<Vector3> spawnObjectCoords;

    // Start is called before the first frame update
    void Start()
    {
        colors[0] = Color.black;
        //spawnObjectCoords = new Dictionary<Vector2, Color>();
        spawnObjectCoords = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        // PaintPixel();
        SpawnPrefab();


    }

    private RaycastHit RaycastDown() {
        RaycastHit hit;// = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 1000);
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.down));
        Physics.Raycast(ray, out hit);
        return hit;
    }

    private void SpawnPrefab() {
        RaycastHit hit = RaycastDown();

    }


    private void PaintPixel() {

        RaycastHit hit = RaycastDown();
        Debug.Log("Hit" + hit.collider.name);
        Renderer rend = hit.transform.GetComponent<Renderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;

        if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
        {
            return;
        }

        Texture2D tex = rend.material.mainTexture as Texture2D;
        Vector2 pixelUV = hit.textureCoord;

        int xCord = (int)pixelUV.x;
        int yCord = (int)pixelUV.y;
        xCord *= tex.width;
        yCord *= tex.height;

        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;


        tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
        tex.Apply();
    }
}
