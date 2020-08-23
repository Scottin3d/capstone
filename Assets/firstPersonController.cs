using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPersonController : MonoBehaviour
{

    private new Rigidbody rigidbody;


    public float mouseSensitivityX = 250f;
    public float mouseSensitivityY = 250f;

    private new Transform camera;
    private float verticalLookRotation;

    private Vector3 moveAmount;
    [SerializeField]
    private float moveSpeed = 2; // player speed
    // boost speed clamp
    // boost multiplier
    private Vector3 smoothMoveVelocity;

    [SerializeField]
    private float jumpForce = 220f;
    public  bool isGrounded = true;

    [SerializeField]
    private LayerMask groundedMask;

    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody = GetComponent<Rigidbody>();
        camera = Camera.main.transform;    
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            isGrounded = false;
            rigidbody.AddForce(transform.up * jumpForce);
        }

        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        // out allows the method to modify the variable &* in c++ 
        // out does not need to be initialized
        if (Physics.Raycast(ray, out hit, 1 + 0.1f, groundedMask)) {
            isGrounded = true;
        }

        /*/ only will call with player in not grounded 
        if (!isGrounded) {
            CheckIfGrounded();
        }
        */
        
    }
    private void FixedUpdate() {
        Movement();
    }

    
    

    // handles camera rotataion
    private void HandleMovement() {
        //transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.smoothDeltaTime * mouseSensitivityX);
        verticalLookRotation += Input.GetAxis("Mouse Y") * Time.smoothDeltaTime * mouseSensitivityY;

        // clamp vaules between locks -- add adjustable variable
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -10, 0);
        //camera.localEulerAngles = Vector3.left * verticalLookRotation;

        // raw -- no native smoothing
        // normalize clamps values
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        Vector3 targetMoveAmount = moveDirection * moveSpeed; // later add boost multiplier

        // ref allows method to modify variable
        // float smoothTime -- lower < Faster <> Slower > higher
        // make adjustable
        //moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, 0.15f);
        moveAmount = targetMoveAmount;
    }

    private void Movement() {
        // MovePosition -- world space
        // player needs to move in local space
        // modify moveAmout into local space with TransformDirection
        rigidbody.MovePosition(rigidbody.position + transform.TransformDirection(moveAmount) * Time.smoothDeltaTime);

    }

    private void CheckIfGrounded() {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        // out allows the method to modify the variable &* in c++ 
        // out does not need to be initialized
        if (Physics.Raycast(ray, out hit, 1 + 0.1f, groundedMask)) {
            isGrounded = true;
        }
    }


}
