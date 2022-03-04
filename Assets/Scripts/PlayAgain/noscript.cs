using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noscript : MonoBehaviour
{
    public GameObject Choice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        Choice.GetComponent<PlayAgainScreenScript>().QuitorReplay = 1;
    }
}
