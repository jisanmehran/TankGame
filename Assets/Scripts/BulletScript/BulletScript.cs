using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;

    void Update()
    {
        this.transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        this.transform.Translate(-Vector2.up * bulletSpeed * Time.deltaTime);
        Debug.Log("Hi");
    }
}
