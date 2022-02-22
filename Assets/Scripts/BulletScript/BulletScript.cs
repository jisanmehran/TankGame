using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;
    public float damage;
    private Rigidbody2D m_rigid2D;
    private Vector3 m_dir;


    private void Start()
    {
        m_rigid2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        this.transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
        Destroy(gameObject, 3f);
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.layer == 9)
        {
            float bulletSpeed = 0;
            this.transform.rotation = Quaternion.Inverse(transform.rotation);
            this.transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
        }

        if (other.gameObject.layer == 12)
        {
            float bulletSpeed = 0;

            this.transform.rotation = Quaternion.Euler(0, 0, (this.transform.rotation.z - 180)) * transform.rotation;
            this.transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
        }
    }
}
