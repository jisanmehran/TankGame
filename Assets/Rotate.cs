using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject Block1;
    public GameObject Block2;
    public GameObject Block3;
    public float RotationSpeed;
    private float rotZ;

    // Update is called once per frame
    void Update()
    {
        rotZ += Time.deltaTime * RotationSpeed;
        
        Block1.transform.rotation = Quaternion.Euler(0,0,rotZ);    
        Block2.transform.rotation = Quaternion.Euler(0,0,rotZ);    
        Block3.transform.rotation = Quaternion.Euler(0,0,rotZ);    
    }
}
