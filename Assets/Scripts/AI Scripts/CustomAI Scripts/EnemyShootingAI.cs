using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingAI : MonoBehaviour
{
    public Transform player;
    public Transform shootPos;
    public float range;
    private float distToPlayer;
    public float timeBtwShots;
    public GameObject bullet;
    public bool Cooldown;
    public float cd;
    public GameObject Tank; 
    public float speed = 2;
    public bool TripleShot = false;
    public float TSBtw;

    private bool shoot;
    // Start is called before the first frame update

    void Start()
    {
        Cooldown = false;
        shoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer <= range)
        {
            shoot = true;
        }

        else if (distToPlayer > range)
        {
            shoot = false;
        }

        if (shoot == true)
        {
            Physics2D.IgnoreLayerCollision (10, 11, true);
        }

        else if (shoot == false)
        {
            Physics2D.IgnoreLayerCollision (10, 11, false);
        }

        if (Cooldown == false)
        {
            if (shoot == true && TripleShot == false)
            {  
                Cooldown = true;
                timeBtwShots = cd;
                GameObject shotBullet = Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            }  
            else if (shoot == true && TripleShot == true)    
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