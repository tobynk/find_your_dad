using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stama_bar : MonoBehaviour
{
    public Slider slider;
    public void SetMaxstama(float maxStamina)
    {
        slider.maxValue = maxStamina;
        slider.value = maxStamina;
    }

    public void Setstama(float stamas)
    {
        slider.value = stamas;
    }
}
