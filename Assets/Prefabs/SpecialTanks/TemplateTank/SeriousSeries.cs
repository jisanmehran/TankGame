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
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = transform.up;
        Cooldown = false;
    }
 
    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * bulletSpeed;
        float rotationz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationz - 90);
        Destroy(gameObject, 10f);
    }

    void FixedUpdate()
    {
        
    }
}
