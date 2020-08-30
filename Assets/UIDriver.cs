using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIDriver : MonoBehaviour {

    public Text speed;
    public playerAttributes playerAttributes;

    // targeting
    public RectTransform screenPoint;
    public Transform targetObject;

    public bool hit;
    public RaycastHit raycastHit;


    // Update is called once per frame
    void Update() {
        UpdateSpeed();
    }

    private void FixedUpdate() {
       DrawLine(screenPoint.position, targetObject.position);
        
    }

    public void UpdateSpeed() {
        speed.text = playerAttributes.speed.ToString();
    }

    private void DrawLine(Vector3 toPoint, Vector3 fromPoint) {

        Debug.DrawLine(toPoint, fromPoint, Color.white);
    }

    private bool RaycastPoint() {
        //RaycastHit hit;
        Vector3 direction = targetObject.position - screenPoint.position;

        if (Physics.Raycast(screenPoint.position, direction, out raycastHit)) {
            if (raycastHit.transform.tag == "Planet") {
                return true;
            }
        }
        return false;
    }
}

