using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttributes : MonoBehaviour
{
    public float speed;
    Vector3 PreviousFramePosition = Vector3.zero;


    private void FixedUpdate() {
        CalculateSpeed();
    }
    public float Speed() {
        return speed;
    }
    private void CalculateSpeed() { 
        // speed calculation
        float movementPerFrame = Vector3.Distance(PreviousFramePosition, transform.position);
        speed = movementPerFrame / Time.deltaTime;
        PreviousFramePosition = transform.position;
    }
}
