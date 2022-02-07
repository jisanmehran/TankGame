using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : MonoBehaviour
{
    
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
        if (other.gameObject.CompareTag("Tank"))
        {
            Debug.Log("Touched");
            Connect2Fire scr = other.gameObject.GetComponent<Connect2Fire>();
            scr.Connect = true;
            Destroy(gameObject);   
        }
    }
}
