using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class playermovemnet : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float turnSmoothTime = 0.1f;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float dashSpeed = 20f;
    public float dashDuration = 0.5f;
    private float turnSmoothVelocity;
    public bool isDashing = false;
    public bool isRunning = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        controller.SimpleMove(Vector3.down * 9.8f); // Apply gravity

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Rotate player towards desired direction
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Check for dash input
            if ((Input.GetKey(KeyCode.LeftShift) || Input.GetMouseButton(1)) && isRunning)
            {
                if (!isDashing)
                {
                    isDashing = true;
                    StartCoroutine(DashCoroutine(moveDir));
                }
            }
            else
            {
                // Regular movement
                float speed = isRunning ? runSpeed : walkSpeed;
                if (!isDashing)
                {
                    controller.Move(moveDir.normalized * speed * Time.deltaTime);
                }
            }
        }
        else
        {
            // If there is no input, don't move the character
            controller.Move(Vector3.zero);
        }

        // Toggle running/walking on 'F' key press
        if (Input.GetKeyDown(KeyCode.F))
        {
            isRunning = !isRunning;
        }
    }

    IEnumerator DashCoroutine(Vector3 dashDirection)
    {
        float dashTimer = 0f;
        while (dashTimer < dashDuration)
        {
            dashTimer += Time.deltaTime;
            controller.Move(dashDirection.normalized * dashSpeed * Time.deltaTime);
            yield return null;
        }
        isDashing = false;
    }
}

