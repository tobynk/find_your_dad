using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;

public class playermovemnet : MonoBehaviour
{
    public float speed = 10.0f;
    private float horizontalInput;
    private float verticalInput; 
    private float fowardinput;
    public GameObject shootingE;
    public CharacterController controller;
    public float turnsmoothtime=0.1f;
    public float turnsmoothvelocity;
    public Transform cam;
    private Rigidbody playerRb; 
    public float jumpForce=10;
    public float gravityModifier;
    public bool isOnGround=true;
    private Vector3 Offset = new Vector3(0, 0, 1);
    private float tragetAngle;
    private float angle;
    public bool running=true;

    // Update is called once per frame
    void Start()
    {
        playerRb= GetComponent<Rigidbody>();
        Physics.gravity*=gravityModifier;
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        //transform.Translate(UnityEngine.Vector3.forward * Time.deltaTime * fowardinput*speed);
        //transform.Translate(UnityEngine.Vector3.right * Time.deltaTime * horizontalInput*speed);
        if (Input.GetKeyDown(KeyCode.Space)&& isOnGround)
        {
            playerRb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            isOnGround=false;
        }
        if(direction.magnitude >=0.1f)
        {
            float tragetAngle = Mathf.Atan2(direction.x,direction.z)*Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle=Mathf.SmoothDampAngle(transform.eulerAngles.y, tragetAngle, ref turnsmoothvelocity, turnsmoothtime);
            transform.rotation = Quaternion.Euler(0f,angle,0f);
            Vector3 movedir =Quaternion.Euler(0f, tragetAngle, 0f)*Vector3.forward;
            controller.Move(movedir.normalized*speed*Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(shootingE, transform.position+ Offset,shootingE.transform.rotation);
        }
    
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground")){
            isOnGround=true;
        }
    } 
         
}
