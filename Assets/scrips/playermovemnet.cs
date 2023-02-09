using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;

public class playermovemnet : MonoBehaviour
{
    public float speed = 10.0f;
    private float jumpSpeed = 5f;
    private float dashSpeed = 20f;
    private float horizontalInput;
    private float verticalInput; 
    private float fowardinput;
    public GameObject shootingE;
    public CharacterController controller;
    public float turnsmoothtime=0.1f;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        //transform.Translate(UnityEngine.Vector3.forward * Time.deltaTime * fowardinput*speed);
        //transform.Translate(UnityEngine.Vector3.right * Time.deltaTime * horizontalInput*speed);
        
        if(direction.magnitude >=0.1f)
        {
            float tragetAngle = Mathf.Atan2(direction.x,direction.z)*Mathf.Rad2Deg;
            float angle=Mathf.SmoothDampAngle(transform.eulerAngles.y, tragetAngle, ref turnsmoothtime)
            transform.rotation = Quaternion.Euler(0f,tragetAngle,0f);
            controller.Move(direction*speed*Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(shootingE, transform.position,shootingE.transform.rotation);
        }
        

    }
}
