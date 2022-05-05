using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyKicks : MonoBehaviour
{
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    private GameObject Tank;
    public GameObject enemy;
    private Animator anim;
    public GameObject FirePoint;
    public GameObject spinParticle;
    public GameObject flamingspinParticle;
    public GameObject hitEffect;
    public AudioClip hitSound;
    public AudioClip enemyHitSound;
    public bool spinning;
    private GameObject SpinEffectIns;
    public GameObject fireParticle;
    public bool recentFireSpawn;
    private AudioSource theaudio;
    public GameObject gameManager;
    public bool DamageOn;
    private float timebtwkicks;
    private float kickcd = 2;
    // Start is called before the first frame update
    void Start()
    {
        Tank = GameObject.Find("KickerTank(Clone)");
        anim = Tank.GetComponent<Animator>();
        theaudio = gameObject.GetComponent<AudioSource>();
        Cooldown = false;
        spinning = false;
        if (Tank.tag == "Player1")
        {
            enemy = GameObject.FindWithTag("Player2");
        }
        else
        {
            enemy = GameObject.FindWithTag("Player1");
        }
        recentFireSpawn = false;
        gameManager = GameObject.Find("GameManager");
        DamageOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cooldown == false)
        {
            if (Input.GetKey(KeyCode.Space) && Tank.GetComponent<TankScript>().isPlayer2Input == false)
            {
                spinning = true;
                anim.SetBool("Spin", true);
                theaudio.clip = hitSound;
                theaudio.Play();
                Cooldown = true;
                timeBtwShots = cd;
                DiableJambe Dscr = Tank.GetComponent<DiableJambe>();
                if (Dscr.DiableLeg == true)
                {
                    SpinEffectIns = Instantiate(flamingspinParticle, FirePoint.transform.position, Quaternion.identity);
                    SpinEffectIns.transform.parent = Tank.transform;
                }
                else if (Dscr.DiableLeg == false)
                {
                    SpinEffectIns = Instantiate(spinParticle, FirePoint.transform.position, Quaternion.identity);
                    SpinEffectIns.transform.parent = Tank.transform;
                }
                
            }

            if (Input.GetKey(KeyCode.Q) && Tank.GetComponent<TankScript>().isPlayer2Input == true)
            {
                spinning = true;
                anim.SetBool("Spin", true);
                theaudio.clip = hitSound;
                theaudio.Play();
                Cooldown = true;
                timeBtwShots = cd;
                DiableJambe Dscr = Tank.GetComponent<DiableJambe>();
                if (Dscr.DiableLeg == true)
                {
                    SpinEffectIns = Instantiate(flamingspinParticle, FirePoint.transform.position, Quaternion.identity);
                    SpinEffectIns.transform.parent = Tank.transform;
                }
                else if (Dscr.DiableLeg == false)
                {
                    SpinEffectIns = Instantiate(spinParticle, FirePoint.transform.position, Quaternion.identity);
                    SpinEffectIns.transform.parent = Tank.transform;
                }
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;      
        }
        if (timeBtwShots <= cd*2/3)
        {
            spinning = false;
            theaudio.Stop();
            anim.SetBool("Spin", false);
            Destroy(SpinEffectIns);
        }
        if (timeBtwShots <= 0)
        {
            Cooldown = false;
        }

        timebtwkicks -= Time.deltaTime;
        if (timebtwkicks <= 0)
        {
            DamageOn = true;
        }

        if (spinning)
        { 
            DiableJambe Dscr = Tank.GetComponent<DiableJambe>();
            if (Dscr.DiableLeg == true)
            {
                StartCoroutine(FireSpawn());
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                spinning = false;
                anim.SetBool("Spin", false);
                Destroy(SpinEffectIns);
                theaudio.Stop();
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                spinning = false;
                anim.SetBool("Spin", false);
                Destroy(SpinEffectIns);
                theaudio.Stop();
            } 
                
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == enemy.name && spinning && DamageOn == true)
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
            DamageOn = false;
            timebtwkicks = kickcd;
        }
    }

    IEnumerator FireSpawn()
    {
        if (recentFireSpawn == false)
        {
            GameObject fireEffectIns = Instantiate(fireParticle, transform.position, Quaternion.identity);
            Destroy(fireEffectIns, 3f);
            recentFireSpawn = true;
            yield return new WaitForSeconds(0.4f);
            recentFireSpawn = false;
        }       
    }
}
