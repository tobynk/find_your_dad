using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour
{
    private playermovemnet PlayerControllerScript;
    public float dashspeed=10;
    public float dashTime=5;


    void Start()
    {
        PlayerControllerScript=GetComponent<playermovemnet>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Dash());
        }
           
        
    }

    IEnumerator Dash()
    {
        float StartTime=Time.time;

        while(Time.time<StartTime+dashTime)
        {
            PlayerControllerScript.controller.Move(dashspeed*Time.deltaTime*playermovemnet.movedir);

            yield return null;
        }
    }
}
