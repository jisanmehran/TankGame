using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed = 20;
    private Vector3 direction;
 
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

    void FixedUpdate()
    {
        Destroy(gameObject, 3f);
    }
 
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
 
        ContactPoint2D contact = collision.GetContact(0);
 
        if (collision.gameObject.layer == 9 | collision.gameObject.layer == 12)
        {
            direction = Vector3.Reflect(direction, contact.normal);
        }
    }
}
