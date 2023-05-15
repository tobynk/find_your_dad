using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stama : MonoBehaviour
{
    public float stamina = 100.0f;
    public float staminaAdd = 1f;
    public float maxStamina = 100.0f;

    void Update()
    {
        if (stamina < maxStamina)
        {
            stamina += staminaAdd * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            UseStamina(10);
        }
    }

    public void UseStamina(float amount)
    {
        stamina -= amount;
    }
}
