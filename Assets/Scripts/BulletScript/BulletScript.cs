using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
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
        if (other.gameObject.tag == "Tank")
        {
            Destroy(gameObject);
            //other.gameObject.GetComponent<"The Tank's health script name here">().TakeDamage(damage);
            //Health decrease here
            //TakeDamage is the name of the damage function and damage is the parameter.
        }
    }
}
