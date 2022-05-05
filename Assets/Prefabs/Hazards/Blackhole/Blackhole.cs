using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : MonoBehaviour
{
    const float G = 66.74f;
    
    public Rigidbody2D rb;

    public static List<Rigidbody2D> Attractors;

    void FixedUpdate()
    {
        Rigidbody2D[] attractors =  Object.FindObjectsOfType<Rigidbody2D>();
        foreach (Rigidbody2D attractor in attractors)
        {
            if (attractor != this)
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
        else if (distance > 10)
        {
            return;
        }

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}
