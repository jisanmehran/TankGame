using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecialHealthScript : MonoBehaviour
{ 


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (collision.gameObject.name != "specialBullet(Clone)")
            {
                if (collision.gameObject.name != "THEPunch(Clone)")
                {
                    if (collision.gameObject.name != "BarrageHit(Clone)")
                    {
                        SceneManager.LoadScene("PlayAgain");
                    }
                }             
            }          
        }
    }
}
