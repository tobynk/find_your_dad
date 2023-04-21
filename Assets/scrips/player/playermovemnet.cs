using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;

public class playermovemnet : MonoBehaviour
{
    public float speed = 14.0f;
    private float horizontalInput;
    private float verticalInput;
    private float fowardinput;
    public CharacterController controller;
    public float turnsmoothvelocity;
    public Transform cam;
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    private float tragetAngle;
    private float angle;


    // Update is called once per frame
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothvelocity, Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
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
