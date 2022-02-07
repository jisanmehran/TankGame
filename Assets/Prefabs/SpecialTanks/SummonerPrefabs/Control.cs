using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public GameObject Master;
    public GameObject Servant;
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    private int ServantNumber;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Cooldown == false)
        {
            if (Input.GetKey(KeyCode.R))
            {  
                // GameObject[] objs = GameObject.FindGameObjectsWithTag("Servant");
                // GameObject closestEnemy = null;
                // float closestDistance;
                // bool first = true;
         
                // foreach (var obj in objs)
                // {
                //     float distance = Vector2.Distance(obj.transform.position, transform.position);
                //     if (first)
                //     {
                //     closestDistance = distance;
                 
                //     first = false;
                //     }            
                //     else if (distance < closestDistance)
                //     {
                //     closestEnemy = obj;
                //     closestDistance = distance;
                //     }                                                         
                // }
                // return closestEnemy;
                Debug.Log("Switch??");
                Cooldown = true;
                timeBtwShots = cd;
                gameObject.GetComponent<TankScript>().enabled = false;
                //closestEnemy.GetComponent<TankScript>().enabled = true;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        if (timeBtwShots <= 0)
        {
            Cooldown = false;
        }
    }
}
