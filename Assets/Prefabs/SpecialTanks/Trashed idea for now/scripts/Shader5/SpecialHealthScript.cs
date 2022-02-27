using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecialHealthScript : MonoBehaviour
{ 


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && collision.gameObject.name != "SpecialBullet")
        {
            //SceneManager.LoadScene("Map1");
            Debug.Log("Hi");
        }
    }
}
