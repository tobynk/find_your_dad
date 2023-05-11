using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bosshealthbar : MonoBehaviour
{
    public Slider emslider;
    public TextMeshProUGUI healthtext;

    public void SetMaxHealth(int emmaxHealth)
    {
        emslider.maxValue = emmaxHealth;
        emslider.value = emmaxHealth;
        Updatehealth();
    }

    public void SetHealth(int health)
    {
        emslider.value = health;
        Updatehealth();
    }
    private void Updatehealth()
    {
        healthtext.text=emslider.value+"/"+emslider.maxValue;
    }
}
