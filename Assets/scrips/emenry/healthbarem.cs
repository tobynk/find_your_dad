using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbarem : MonoBehaviour
{
    public slider emslider;

    public void SetMaxHealth(int emmaxHealth)
    {
        emslider.maxValue = emmaxHealth;
        emslider.value = emmaxHealth;
    }

    public void SetHealth(int health)
    {
        emslider.value = health;
    }
}
