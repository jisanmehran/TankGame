using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;
    public float modifiedSpeed;
    public float damage;
    public bool InVFX;
    public GameObject RangeVFX;
    public bool Stop;
    public GameObject TSTank;
    public bool isTS;
    //public int damage;
    // Start is called before the first frame update
    void Update()
    {
        if (InVFX == true)
        {
            this.transform.Translate(Vector2.up * modifiedSpeed * Time.deltaTime);
            Debug.Log("true");
        }
        else if (Stop == true)
        {
            this.transform.Translate(Vector2.up * 0 * Time.deltaTime);
            Debug.Log("stop");
        }
        else
        {
            this.transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
            Debug.Log("else");
        }

        if (RangeVFX == null)
        {
            InVFX = false;
        }

        TimeStop scr = TSTank.GetComponent<TimeStop>();
        scr.TimeStopped = isTS;
        if (isTS)
        {
            Stop = true;
            Debug.Log("TimeStopped");
        }
        //Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("VFX"))
        {
           Slow scr = other.gameObject.GetComponent<Slow>();   
           if (scr.Active == true)  
           {
               InVFX = true;
               Debug.Log("in");
           }
        }
        else
        {
            //Destroy(gameObject);
        }
        
    }

    void OnTriggerStay2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("VFX"))
        {
           Slow scr = other.gameObject.GetComponent<Slow>();   
           if (scr.Active == true)  
           {
               InVFX = true;
               Debug.Log("stay");
           }
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("VFX"))
        {
            InVFX = false;
            Debug.Log("out");
        }
        else
        {
            //Destroy(gameObject);
        }
        
    }
}
