using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServantDamage : MonoBehaviour
{
    public GameObject Tank;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet" && other.gameObject.name != "ServantBullet(Clone)")
        {
            
            Destroy(Tank);
            Destroy(other.gameObject);
        }
    }
}
