using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    public int Health;
    public int maxHealth = 2;
    public int currentHealth;
    public Slider slider;


    //public HealthBar healthBar;

    void Start()
    {
        Health = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Shell")
        {
            Health = Health - 50;
            //healthBar.SetHealth(Health);
        }
    }
    void Update()
    {

    }
   
    
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
