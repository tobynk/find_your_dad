using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbarem : MonoBehaviour
{
    public Slider emslider;
    public healthbar healthBar;

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
