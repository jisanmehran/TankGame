using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public int maxHealth = 100;
    public int Health;


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
}
