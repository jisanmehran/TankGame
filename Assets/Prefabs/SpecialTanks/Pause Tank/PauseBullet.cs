using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBullet : MonoBehaviour
{
    public float bulletSpeed;
    public float damage;
    //public int damage;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        this.transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("VFX"))
        {
    
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
