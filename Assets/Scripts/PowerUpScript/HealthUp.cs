using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
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
            Destroy(gameObject);
            //EnemyBehavior scr = transform.parent.gameObject.GetComponent<EnemyBehavior>();
            //scr.PlayerInLongRange = true;
            //Use this above to increase the health of the tank
        }
    }
}
