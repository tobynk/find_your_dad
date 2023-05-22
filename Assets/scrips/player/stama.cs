using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stama : MonoBehaviour
{
    public float stamina = 100.0f;
    public float staminaAdd = 1f;
    public float maxStamina = 100.0f;
    public stama_bar stamabar;
    public bool stama_bar= false;
    public activethehealthbar sethealthbar;
    private float timer=0;
    private float todeactive=5;
    

    void Start()
    {
        stamabar = GameObject.FindObjectOfType<stama_bar>();
        stamabar.SetMaxstama(maxStamina);
        sethealthbar = FindObjectOfType<activethehealthbar>();
    }

    void Update()
    {
        stamabar.Setstama(stamina);
        if (stamina < maxStamina)
        {
            stamina += staminaAdd * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            UseStamina(10);
        }
        if (stamina==maxStamina)
        {
            timer += Time.deltaTime;
        }
        if (timer>=todeactive)
        {
            timer=0;
            sethealthbar.stamabarsetdeactive();
        }
    }

    public void UseStamina(float amount)
    {
        timer=0;
        sethealthbar.stamabarsetactive();
        stamina -= amount;
        timer=0;
        stamabar.Setstama(stamina);
    }
}
