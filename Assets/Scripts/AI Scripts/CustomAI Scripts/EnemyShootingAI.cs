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

    // IEnumerator Shoot()
    // {
    //     yield return new WaitForSeconds(1);
    //     GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
    //     newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * Time.fixedDeltaTime, 0f);

    // }
    // public Transform target;    
    // public Transform projectile;
    // public float maximumLookDistance = 30f;
    // public float maximumAttackDistance = 10f;
    // public float minimumDistanceFromPlayer  = 2f;
    // public float rotationDamping = 2f;
    // public float shotInterval = 0.5f;
    // private float shotTime = 0f;
 
    // //Functions

    // private void Update()
    // {
    //     var distance = Vector2.Distance(target.position, transform.position);

    //     if(distance <= maximumLookDistance)
    //     {
    //         LookAtTarget();

    //         //Check distance and time
    //         if(distance <= maximumAttackDistance && (Time.time - shotTime) > shotInterval)
    //         {
    //             Shoot();
    //         }
    //     }   
    // }
 
    // private void LookAtTarget()
    // {
    //     Vector2 dir = target.position - transform.position;
    //     dir.y = 0;
    //     var rotation = Quaternion.LookRotation(dir);
    //     transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
    // }


    // private void Shoot()
    // {
    //     //Reset the time when we shoot
    //     shotTime = Time.time;
    //     Instantiate(projectile, transform.position + (target.position - transform.position).normalized, Quaternion.LookRotation(target.position - transform.position));
    // }

//}
