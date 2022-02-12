using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GilgameshHealth : MonoBehaviour
{ 
    public int maxHealth = 3;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Shell")
        {
            currentHealth = currentHealth - 1;
        }
    }

    void Update()
    {
        if (currentHealth == 0)
        {
            Debug.Log("Hi");
        }
    }
}
