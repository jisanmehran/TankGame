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
    public bool Possessed;
    public Servant thePossessed;
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
                
                if (Possessed == false)
                {
                    float distanceToClosestServant = Mathf.Infinity;
                    Servant closestServant = null;
                    //Edit Servant in the FindObjectsOfType to a component on the object you
                    //want to find nearest 
                    Servant[] allServants = GameObject.FindObjectsOfType<Servant>();

                    foreach (Servant currentServant in allServants)
                    {
                        float distanceToServant = (currentServant.transform.position - this.transform.position).sqrMagnitude;
                        if (distanceToServant < distanceToClosestServant)
                        {
                            distanceToClosestServant = distanceToServant;
                            closestServant = currentServant;
                            thePossessed =  closestServant; 
                        }
                    }
                    Debug.Log("Switch To");
                    Cooldown = true;
                    timeBtwShots = cd;
                    gameObject.GetComponent<TankScript>().enabled = false;
                    closestServant.GetComponent<TankScript>().enabled = true;
                    Possessed = true;
                }
                else if (Possessed == true)
                {
                    Debug.Log("Switch Back");
                    Cooldown = true;
                    timeBtwShots = cd;
                    gameObject.GetComponent<TankScript>().enabled = true;
                    thePossessed.GetComponent<TankScript>().enabled = false;
                    Possessed = false;
                }  
                    
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
