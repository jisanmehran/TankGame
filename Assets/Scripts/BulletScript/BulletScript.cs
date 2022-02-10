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
    //public int damage;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (InVFX == true)
        {
            this.transform.Translate(Vector2.up * modifiedSpeed * Time.deltaTime);
        }
        else
        {
            this.transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
        }
        if (RangeVFX == null)
        {
            InVFX = false;
        }
        Destroy(gameObject, 3f);
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
           }
        }
        else
        {
            Destroy(gameObject);
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
           }
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("VFX"))
        {
            InVFX = false;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
