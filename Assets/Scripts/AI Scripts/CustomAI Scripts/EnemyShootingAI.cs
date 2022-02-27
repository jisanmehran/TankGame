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

    private GameObject GameControl;

    // Start is called before the first frame update

    void Start()
    {
        GameControl = GameObject.Find("GameControl");
        Cooldown = false;
        shoot = false;
        if (GameControl.GetComponent<GameControl>().TargetPlayer1 == false)
        {
            player = GameObject.FindWithTag("Player2").transform;
        }

        if (GameControl.GetComponent<GameControl>().TargetPlayer1 == true)
        {
            player = GameObject.FindWithTag("Player1").transform;				
        }
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject, 1f);
        }
    }

}