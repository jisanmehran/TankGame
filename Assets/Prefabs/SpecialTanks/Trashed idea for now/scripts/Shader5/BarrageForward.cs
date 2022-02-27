using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageForward : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed = 20;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = transform.up;
        rb.velocity = direction * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Destroy(gameObject, 0.2f);
    }
}
