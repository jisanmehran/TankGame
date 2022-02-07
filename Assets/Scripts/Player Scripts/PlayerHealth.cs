using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 2;
    public int currentHealth;
    public Slider slider;
    
    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;  
    }

    public void SetHealth(int currentHealth)
    {
        slider.value = currentHealth;
    }
    
}
