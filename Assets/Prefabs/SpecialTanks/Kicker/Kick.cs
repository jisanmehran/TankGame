using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    public bool hit;
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    private GameObject Tank;
    public GameObject enemy;
    private Animator anim;
    public GameObject FirePoint;
    public GameObject VFXPoint;
    public GameObject hitEffect;
    public GameObject kickParticle;
    public GameObject flamekickParticle;
    private float originalSpeed;
    public float dashSpeed;
    public float dashLength = .5f, dashCooldown = 1f;
    private float dashCounter;
    public AudioClip hitSound;
    public AudioClip enemyHitSound;
    public GameObject fireParticle;
    private AudioSource theaudio;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        Tank = GameObject.Find("KickerTank(Clone)");
        TankScript scr = Tank.GetComponent<TankScript>();
        originalSpeed = scr.moveSpeedMax;
        anim = Tank.GetComponent<Animator>();
        theaudio = gameObject.GetComponent<AudioSource>();
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
                anim.SetTrigger("Kick");
                theaudio.clip = hitSound;
                theaudio.Play();
                TankScript scr = Tank.GetComponent<TankScript>();
                scr.moveSpeedMax = dashSpeed;
                dashCounter = dashLength;
                Cooldown = true;
                timeBtwShots = cd;
                DiableJambe Dscr = Tank.GetComponent<DiableJambe>();
                if (Dscr.DiableLeg == true)
                {
                    GameObject FKickEffectIns = Instantiate(flamekickParticle, VFXPoint.transform.position, VFXPoint.transform.rotation);
                    FKickEffectIns.transform.parent = VFXPoint.transform;
                    Destroy(FKickEffectIns, 0.7f);
                    StartCoroutine(FireSpawn());
                }
                else if (Dscr.DiableLeg == false)
                {
                    GameObject KickEffectIns = Instantiate(kickParticle, VFXPoint.transform.position, VFXPoint.transform.rotation);
                    KickEffectIns.transform.parent = VFXPoint.transform;
                    Destroy(KickEffectIns, 0.7f);
                }
            }

            if (Input.GetKey(KeyCode.A) && Tank.GetComponent<TankScript>().isPlayer2Input == true)
            {
                hit = true;
                anim.SetTrigger("Kick");
                theaudio.clip = hitSound;
                theaudio.Play();
                TankScript scr = Tank.GetComponent<TankScript>();
                scr.moveSpeedMax = dashSpeed;
                dashCounter = dashLength;
                Cooldown = true;
                timeBtwShots = cd;
                DiableJambe Dscr = Tank.GetComponent<DiableJambe>();
                if (Dscr.DiableLeg == true)
                {
                    GameObject FKickEffectIns = Instantiate(flamekickParticle, VFXPoint.transform.position, VFXPoint.transform.rotation);
                    FKickEffectIns.transform.parent = VFXPoint.transform;
                    Destroy(FKickEffectIns, 0.7f);
                    StartCoroutine(FireSpawn());
                }
                else if (Dscr.DiableLeg == false)
                {
                    GameObject KickEffectIns = Instantiate(kickParticle, VFXPoint.transform.position, VFXPoint.transform.rotation);
                    KickEffectIns.transform.parent = VFXPoint.transform;
                    Destroy(KickEffectIns, 0.7f);
                }
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

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                TankScript scr = Tank.GetComponent<TankScript>();
                scr.moveSpeedMax = originalSpeed;
                hit = false;
                theaudio.Stop();
            }
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

    IEnumerator FireSpawn()
    {
        GameObject fireEffectIns = Instantiate(fireParticle, transform.position, Quaternion.identity);
        Destroy(fireEffectIns, 4f);
        yield return new WaitForSeconds(dashLength);
        GameObject fireEffectIns2 = Instantiate(fireParticle, transform.position, Quaternion.identity);
        Destroy(fireEffectIns2, 4f);
    }
}
