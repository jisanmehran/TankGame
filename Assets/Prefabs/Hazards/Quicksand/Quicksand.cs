using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quicksand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            TankScript scr = other.gameObject.GetComponent<TankScript>();
            scr.moveSpeedMax = 2.5f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            TankScript scr = other.gameObject.GetComponent<TankScript>();
            scr.moveSpeedMax = 5;
            if (other.gameObject.name == "KickerTank(Clone)" || other.gameObject.name == "SwordTank(Clone)")
            {
                scr.moveSpeedMax = 6;
            }
        }
    }
}
