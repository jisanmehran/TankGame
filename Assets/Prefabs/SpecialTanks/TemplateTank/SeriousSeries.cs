using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeriousSeries : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed = 20;
    private Vector3 direction;
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    public GameObject Tank;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = transform.up;
        Cooldown = false;
        Ignore();
        Tank = GameObject.Find("One's Greatest High(Clone)");
    }

 
    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * bulletSpeed;
        float rotationz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationz - 90);
        Destroy(gameObject, 10f);
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>()); 
    }

    void Ignore()
    {
        Physics2D.IgnoreLayerCollision(13, 9, true);
        Physics2D.IgnoreLayerCollision(13, 12, true);

        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), Tank.GetComponent<Collider2D>());
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject);
    }
}
