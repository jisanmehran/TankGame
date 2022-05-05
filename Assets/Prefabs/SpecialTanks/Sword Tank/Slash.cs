using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public bool hit;
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    public GameObject Tank;
    public GameObject enemy;
    private Animator anim;
    public GameObject FirePoint;
    public GameObject hitEffect;
    public GameObject slashParticle;
    public AudioClip hitSound;
    public AudioClip enemyHitSound;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        anim = Tank.GetComponent<Animator>();
        Cooldown = false;
        hit = false;
        if (Tank.tag == "Player1")
        {
            enemy = GameObject.FindWithTag("Player2");
        }
        else
        {
            enemy = GameObject.FindWithTag("Player1");
        }
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Cooldown == false)
        {
            if (Input.GetKey(KeyCode.LeftControl) && Tank.GetComponent<TankScript>().isPlayer2Input == false)
            { 
                hit = true;
                anim.SetTrigger("Slash");
                AudioSource audio = Tank.GetComponent<AudioSource>();
                audio.clip = hitSound;
                audio.Play();
                Cooldown = true;
                timeBtwShots = cd;
                GameObject SlashEffectIns = Instantiate(slashParticle, FirePoint.transform.position, Quaternion.identity);
                SlashEffectIns.transform.parent = Tank.transform;
                Destroy(SlashEffectIns, 0.9f);
            }

            if (Input.GetKey(KeyCode.A) && gameObject.GetComponent<TankScript>().isPlayer2Input == true)
            {
                hit = true;
                anim.SetTrigger("Slash");
                AudioSource audio = Tank.GetComponent<AudioSource>();
                audio.clip = hitSound;
                audio.Play();
                Cooldown = true;
                timeBtwShots = cd;
                GameObject SlashEffectIns = Instantiate(slashParticle, FirePoint.transform.position, Quaternion.identity);
                SlashEffectIns.transform.parent = Tank.transform;
                Destroy(SlashEffectIns, 0.9f);
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

        if (timeBtwShots <= cd/2)
        {
            hit = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (hit == true)
        {
            if (other.gameObject.name == enemy.name)
            {
                HealthScript scr = enemy.GetComponent<HealthScript>();
                AudioSource audio = enemy.GetComponent<AudioSource>();
                audio.clip = enemyHitSound;
                audio.Play();
                if (enemy.tag == "Player1")
                {
                    gameManager.GetComponent<gamemanagerscript>().player1hitCount++;
                }
                else
                {
                    gameManager.GetComponent<gamemanagerscript>().player2hitCount++;
                }
                scr.alreadycounted = true;
                scr.Invoke("ResetBullets", 2f);
                GameObject hitEffectIns = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(hitEffectIns, 0.9f);
                hit = false;
            }
        }
    }
}
