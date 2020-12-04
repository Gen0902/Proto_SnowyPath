using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Scene set up")]
    public Camera playerCamera;
    [SerializeField] Transform groundChecker;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;

    [Header("Stats")]
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 10f;
    public float jumpForce = 10f;

    [Header("Camera")]
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    [SerializeField] bool canMove = true;

    //private
    private Rigidbody rigidBody;
    private Vector3 inputs = Vector3.zero;
    private bool isGrounded = true;

    private Vector3 xyMove = Vector3.zero;
    private float rotationX = 0;
    private float currentSpeed = 0;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //Update state
        isGrounded = Physics.CheckSphere(groundChecker.position, groundCheckRadius, groundLayer, QueryTriggerInteraction.Ignore);
        currentSpeed = (Input.GetKey(KeyCode.LeftShift)) ? runningSpeed : walkingSpeed;

        //Update Axis
        inputs.x = Input.GetAxis("Horizontal");
        inputs.z = Input.GetAxis("Vertical");

        Vector3 lookDirection = playerCamera.transform.TransformDirection(Vector3.forward);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = currentSpeed * inputs.x;
        float curSpeedZ = currentSpeed * inputs.z;
        xyMove = (forward * curSpeedZ) + (right * curSpeedX);

        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }

        //Apply gravity
        //if (!isGrounded)
        //    moveDirection.y -= gravity * Time.deltaTime;

        //Camera 
        Rotate();
    }

    void FixedUpdate()
    {
        if (canMove)
            rigidBody.MovePosition(rigidBody.position + xyMove * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundChecker.position, groundCheckRadius);
    }

}
