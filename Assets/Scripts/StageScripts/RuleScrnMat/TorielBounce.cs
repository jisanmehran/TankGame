using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorielBounce : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed = 10;
    private Vector3 direction;
    //public AudioClip bounceSound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = transform.up;
    }
 
    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * bulletSpeed;
        float rotationz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationz - 90);
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
 
        ContactPoint2D contact = collision.GetContact(0);
 
        if (collision.gameObject.layer == 9 | collision.gameObject.layer == 12)
        {
            direction = Vector3.Reflect(direction, contact.normal);
            //AudioSource audio = gameObject.GetComponent<AudioSource>();
            //audio.clip = bounceSound;
            //audio.Play();
        }

        if (collision.gameObject.layer == 10)
        {
            Physics2D.IgnoreLayerCollision (10, 10, true);
        }
    }
}
