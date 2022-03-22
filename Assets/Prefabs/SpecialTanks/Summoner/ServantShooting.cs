using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ServantShooting : MonoBehaviour
{
    public Transform player;
    public float range;
    private float distToPlayer;

    public GameObject Tank; 
    public float speed = 2;

    public AudioClip fireSound;
    public float fieldofImpact;
    public float force;
    public LayerMask LayerToHit;
    private GameObject GameControl;
    public bool firerange;

    public GameObject bullet;
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;

    private GameObject Player1;
    private GameObject Player2;
    public float AlreadyCounted = 0;


    void Start()
    {
        Player1 = GameObject.FindGameObjectWithTag("Player1");
        Player2 = GameObject.FindGameObjectWithTag("Player2");
        firerange = false;
        GameControl = GameObject.Find("GameControl");

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
            firerange = true;
        }

        else if (distToPlayer > range)
        {
            firerange = false;
        }

        if (firerange == true)
        {
            explode();
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    void explode()
    {

        // if (obj.gameObject.tag == "Player1" && AlreadyCounted == 0)
        // {
        //     Player1.GetComponent<HealthScript>().Invoke("player1deathiterator", 2f);
        //     AlreadyCounted++;
        // }

        // if (obj.gameObject.tag == "Player2" && AlreadyCounted == 0)
        // {
        //     Player2.GetComponent<HealthScript>().Invoke("player2deathiterator", 2f);
        //     AlreadyCounted++;
        // }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldofImpact);
    } 

}