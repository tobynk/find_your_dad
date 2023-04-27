using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;

public class playermovemnet : MonoBehaviour
{
    public CharacterController controller;
    public float turnsmoothtime = 0.1f;
    public float turnsmoothvelocity;
    public Transform cam;
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    private float tragetAngle;
    private float angle;
    public float speed = 10;

    // Jump variables
    public float jumpHeight = 3f;
    public float timeToJumpApex = 0.4f;
    private float jumpVelocity;

    // Update is called once per frame
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        Cursor.lockState = CursorLockMode.Locked;

        // Calculate jump velocity
        float gravity = Physics.gravity.y;
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Rotate player towards desired direction
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothvelocity, turnsmoothtime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            // If there is no input, don't move the character
            controller.Move(Vector3.zero);
        }

        // Check for jump input and apply force to player
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            // Calculate jump force based on desired height
            float jumpForce = Mathf.Sqrt(2f * jumpHeight * Mathf.Abs(Physics.gravity.y));
            playerRb.velocity = Vector3.up * jumpForce;

            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isOnGround = true;
        }
    }
}

