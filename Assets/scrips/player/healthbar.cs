using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class healthbar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI healthtext;

    public void SetMaxHealth(int maxHealth)
    {
        Debug.Log(maxHealth);
        var val = Mathf.Clamp(maxHealth, 0, 999999);
        slider.maxValue = val;
        slider.value = val;
        Updatehealth();
    }

    public void SetHealth(int health)
    {
        var val = Mathf.Clamp(health, 0, 999999);
        slider.value = health;
        Updatehealth();
    }

    private void Updatehealth()
    {
        healthtext.text=slider.value+"/"+slider.maxValue;
    }
}
