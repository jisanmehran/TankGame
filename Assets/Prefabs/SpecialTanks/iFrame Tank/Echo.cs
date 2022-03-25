using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echo : MonoBehaviour
{
    public float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public GameObject echo;
    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            Instantiate(echo, transform.position, transform.rotation);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
