using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringScript : MonoBehaviour
{
    public GameObject bullet;
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    public GameObject Tank; 
    public float speed = 2;
    public bool TripleShot = false;
    public float TSBtw;
    // Start is called before the first frame update

    void Start()
    {
        Cooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cooldown == false)
        {
            if (Input.GetKey(KeyCode.Space) && TripleShot == false)
            {  
                Cooldown = true;
                timeBtwShots = cd;
                GameObject shotBullet = Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            }  
            else if (Input.GetKey(KeyCode.Space) && TripleShot == true)    
            {
                Cooldown = true;
                timeBtwShots = cd;
                GameObject shotBullet = Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                //need wait
                GameObject shotBullet2 = Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                //need wait
                GameObject shotBullet3 = Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                TripleShot = false;
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
