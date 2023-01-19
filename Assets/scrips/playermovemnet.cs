using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class playermovemnet : MonoBehaviour
{
    private float speed = 5.0f;
    private float jumpSpeed = 5f;
    private float dashSpeed = 20f;
    private float horizontalInput;
    private float verticalInput; 
    private float fowardinput;
    public GameObject shootingE;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        fowardinput = Input.GetAxis("Vertical");
        //making the car go
        transform.Translate(UnityEngine.Vector3.forward * Time.deltaTime * fowardinput*speed);
        transform.Translate(UnityEngine.Vector3.right * Time.deltaTime * horizontalInput*speed);
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(shootingE, transform.position,shootingE.transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
        }

    }
}
