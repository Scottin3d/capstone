using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPersonController : MonoBehaviour
{

    public float mouseSensitivityX = 250f;
    public float mouseSensitivityY = 250f;

    Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivityX);
    }
}
