using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBulletMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed = 20;
    private Vector3 direction;
    public AudioClip bounceSound;
    private GameObject kicker;
    private GameObject enemy; 
    public GameObject hitEffect;
    public GameObject fireParticle;
    public bool recentFireSpawn;
    public GameObject shockwave;
    public AudioClip hitSound;
    public GameObject gameManager;
    //public float maxDeg;
    //public GameObject WindPoint;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = transform.up;
        kicker = GameObject.Find("KickerTank(Clone)");
        if (kicker.tag == "Player1")
        {
            enemy = GameObject.FindWithTag("Player2");
        }
        else if (kicker.tag == "Player2")
        {
            enemy = GameObject.FindWithTag("Player1");
        }
        recentFireSpawn = false;
        gameManager = GameObject.Find("GameManager");
    }

    void Awake()
    {
    }
 
    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * bulletSpeed;
        float rotationz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        DiableJambe Dscr = kicker.GetComponent<DiableJambe>();
        if (Dscr.DiableLeg == true)
        {
            StartCoroutine(FireSpawn());
        }
    }

    void FixedUpdate()
    {
        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(gameObject);
            GameObject shockEffectIns = Instantiate(shockwave, transform.position, Quaternion.identity);
            Destroy(shockEffectIns, 0.3f);
            AudioSource audio = kicker.GetComponent<AudioSource>();
            audio.clip = hitSound;
            audio.Play();
        }
        if (other.gameObject.layer == 12)
        {
            Destroy(gameObject);
            GameObject shockEffectIns = Instantiate(shockwave, transform.position, Quaternion.identity);
            Destroy(shockEffectIns, 0.3f);
            AudioSource audio = kicker.GetComponent<AudioSource>();
            audio.clip = hitSound;
            audio.Play();
        }
        if (other.gameObject.name == enemy.name)
        {
            HealthScript scr = enemy.GetComponent<HealthScript>();
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
            Destroy(gameObject);
        }
    }

    IEnumerator FireSpawn()
    {
        if (recentFireSpawn == false)
        {
            GameObject fireEffectIns = Instantiate(fireParticle, transform.position, Quaternion.identity);
            Destroy(fireEffectIns, 2f);
            recentFireSpawn = true;
            yield return new WaitForSeconds(0.1f);
            recentFireSpawn = false;
        }       
    }
}
