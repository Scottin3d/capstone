using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField]
    private Transform cam;

    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private float speed = 25f;

    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // A -1 <> 1 D
        float veritcal = Input.GetAxisRaw("Vertical"); // S -1 <> 1 W
        Vector3 direction = new Vector3(horizontal, 0f, veritcal).normalized;

        if (direction.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.localEulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            // when working with movement, it is good practive to normalize values
            controller.Move(moveDirection.normalized * speed * Time.smoothDeltaTime);
        }
    }
}
