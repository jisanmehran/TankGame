using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    const float G = 66.74f;
    
    public Rigidbody2D rb;

    public static List<Rigidbody2D> Attractors;

    private GameObject SwdTank;

    private Rigidbody2D swordRb;

    void Awake()
    {
        SwdTank = GameObject.Find("LightsaberTank(Clone)");
    }

    void FixedUpdate()
    {
        Rigidbody2D[] attractors =  Object.FindObjectsOfType<Rigidbody2D>();
        foreach (Rigidbody2D attractor in attractors)
        {
            SwdTank = GameObject.Find("LightsaberTank(Clone)");
            swordRb = SwdTank.GetComponent<Rigidbody2D>();
            if (attractor != this && attractor != swordRb)
            {
                Attract(attractor);
            }            
        }
    }
    
    void Attract (Rigidbody2D objToAttract)
    {
        Rigidbody2D rbToAttract = objToAttract.GetComponent<Rigidbody2D>();

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0f)
        {
            return;
        }
        else if (distance > 20)
        {
            return;
        }

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}
