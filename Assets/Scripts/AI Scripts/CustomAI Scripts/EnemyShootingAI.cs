using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class EnemyShootingAI : MonoBehaviour
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
    public bool explodebomb;

    public GameObject ExplosionEffect;

    private GameObject Player1;
    private GameObject Player2;
    public float AlreadyCounted = 0;


    void Start()
    {
        Player1 = GameObject.FindGameObjectWithTag("Player1");
        Player2 = GameObject.FindGameObjectWithTag("Player2");
        explodebomb = false;
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
            explodebomb = true;
        }

        else if (distToPlayer > range)
        {
            explodebomb = false;
        }

        if (explodebomb == true)
        {
            explode();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject, 1f);
        }
    }

    void explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, LayerToHit);

        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            if (obj.gameObject.tag == "Player1" && AlreadyCounted == 0)
            {
                Player1.GetComponent<HealthScript>().Invoke("player1deathiterator", 3f);
                AlreadyCounted++;
            }

            if (obj.gameObject.tag == "Player2" && AlreadyCounted == 0)
            {
                Player2.GetComponent<HealthScript>().Invoke("player2deathiterator", 3f);
                AlreadyCounted++;
            }
        }

        CameraShaker.Instance.ShakeOnce(4, 4, 0.1f, 1f);
        GameObject ExplosionEffectIns = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(ExplosionEffectIns, 3f);
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldofImpact);
    } 

}