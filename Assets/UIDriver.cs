using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIDriver : MonoBehaviour
{


    public Text speed;
    public GameObject screenPoint;
    private Vector3 playerPositionScreenPoint;
    private Vector3 playerPositionWorldSpace;


    public playerAttributes playerAttributes;
    public Transform player;
    

    // Update is called once per frame
    void Update()
    {
        UpdateSpeed();
    }

    public void UpdateSpeed() {
        speed.text = playerAttributes.speed.ToString();

        //playerPositionScreenPoint = Camera.main.WorldToScreenPoint(screenPoint.transform.position);
        playerPositionScreenPoint = screenPoint.transform.position;
        playerPositionWorldSpace = Camera.main.WorldToScreenPoint(player.position);
        DrawLine(playerPositionWorldSpace, playerPositionScreenPoint);
    }

    private void DrawLine(Vector3 toPoint, Vector3 fromPoint) {
        Debug.DrawLine(toPoint, fromPoint, Color.white);
    }
}

