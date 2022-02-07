using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connect2Fire : MonoBehaviour
{
    public bool Connect = false;
    public GameObject FirePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Connect == true)
        {
            FiringScript scr = FirePoint.GetComponent<FiringScript>();
            scr.TripleShot = true;
        }
    }
}
