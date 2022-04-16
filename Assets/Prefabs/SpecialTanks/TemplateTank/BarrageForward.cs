using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageForward : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed = 20;
    private Vector3 direction;
    public float time;
    public GameObject Tank;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = transform.up;
        rb.velocity = direction * bulletSpeed;
        time = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            Time.timeScale = time/5f;
        }
        else
        {
            time = 0;
            Time.timeScale = 1.0f;
        }
    }

    void FixedUpdate()
    {
        Destroy(gameObject, 0.2f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet" && other.gameObject.name != "BarrageHit(Clone)")
        {
            Destroy(other.gameObject);
        }
    }
}
