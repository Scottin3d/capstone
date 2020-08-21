using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    
    public float gravity = -10f;
    public void Attract(Rigidbody body) {
        // get direction for quaterion
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.transform.up;

        // gives rotation between two vectors
        body.rotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;

        // simulate downward force 'gravity'
        body.AddForce(gravityUp * gravity);

    }
    
}
