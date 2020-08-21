using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private float moveHorizontal;
    private float moveVertical;
    private void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        HandleMovement(movement);
    }

    private void HandleMovement(Vector3 move) {

        transform.GetComponent<Rigidbody>().MovePosition(move);
    }
}
