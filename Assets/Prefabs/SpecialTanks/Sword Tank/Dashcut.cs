using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashcut : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    public GameObject Tank;
    private Vector3 direction;
    public float dashSpeed = 5;
    public GameObject FirePoint;
    public bool dashing;
    public float Range;
    private GameObject enemy;
    public LayerMask Ignore;
    public AudioClip dashCutAud;
    public GameObject slashesEffect;
    public TrailRenderer Trail;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = transform.up;
        if (Tank.tag == "Player1")
        {
            enemy = GameObject.FindWithTag("Player2");
        }
        else if (Tank.tag == "Player2")
        {
            enemy = GameObject.FindWithTag("Player1");
        }
        print(enemy);
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Cooldown == false)
        {
            if (Input.GetKey(KeyCode.LeftAlt) && Tank.GetComponent<TankScript>().isPlayer2Input == false)
            { 
               
                Cooldown = true;
                timeBtwShots = cd;
                RaycastHit2D rayInfo = Physics2D.Raycast(new Vector2(FirePoint.transform.position.x, FirePoint.transform.position.y),FirePoint.transform.up,Range,~Ignore);
                if(rayInfo)
                {
                    print(rayInfo.collider.gameObject.name);
                    if(rayInfo.collider.gameObject.name == enemy.name && rayInfo.collider.gameObject.name != Tank.name)
                    {
                        enemy.GetComponent<TankScript>().enabled = false;
                        if (enemy.name != "KickerTank(Clone)")
                        {
                            enemy.GetComponentInChildren<FiringScript>().enabled = false;
                        }
                        else if (enemy.name == "KickerTank(Clone)")
                        {
                            enemy.GetComponentInChildren<DiableJambe>().enabled = false;
                            enemy.GetComponentInChildren<PartyKicks>().enabled = false;
                            enemy.GetComponentInChildren<WindBullet>().enabled = false;
                            enemy.GetComponentInChildren<Kick>().enabled = false;
                        }
                        StartCoroutine(CutEffect());
                        dashing = true;
                        Trail.emitting = true;
                    }
                    else if(rayInfo.collider.gameObject.layer == 9 || rayInfo.collider.gameObject.layer == 12)
                    {
                        return;
                        Trail.emitting = false;
                    }
                    else
                    {
                        StartCoroutine(TrailEffect());
                        Trail.emitting = false;
                        dashing = true;
                    }
                    
                }
                else if(rayInfo == false)
                {
                    StartCoroutine(TrailEffect());
                }
            }
            if (Input.GetKey(KeyCode.S) && gameObject.GetComponent<TankScript>().isPlayer2Input == true)
            {
                Cooldown = true;
                timeBtwShots = cd;
                dashing = true;
                Trail.emitting = true;
                RaycastHit2D rayInfo = Physics2D.Raycast(new Vector2(FirePoint.transform.position.x, FirePoint.transform.position.y),FirePoint.transform.up,Range,~Ignore);
                if(rayInfo)
                {
                    print(rayInfo.collider.gameObject.name);
                    if(rayInfo.collider.gameObject.name == enemy.name && rayInfo.collider.gameObject.name != Tank.name)
                    {
                        enemy.GetComponent<TankScript>().enabled = false;
                        if (enemy.name != "KickerTank(Clone)")
                        {
                            enemy.GetComponentInChildren<FiringScript>().enabled = false;
                        }
                        else if (enemy.name == "KickerTank(Clone)")
                        {
                            enemy.GetComponentInChildren<DiableJambe>().enabled = false;
                            enemy.GetComponentInChildren<PartyKicks>().enabled = false;
                            enemy.GetComponentInChildren<WindBullet>().enabled = false;
                            enemy.GetComponentInChildren<Kick>().enabled = false;
                        }
                        StartCoroutine(CutEffect());
                        dashing = true;
                        Trail.emitting = true;
                    }
                    else if(rayInfo.collider.gameObject.layer == 9 || rayInfo.collider.gameObject.layer == 12)
                    {
                        return;
                        Trail.emitting = false;
                    }
                    else
                    {
                        StartCoroutine(TrailEffect());
                        Trail.emitting = false;
                        dashing = true;
                    }
                }
                else if(rayInfo == false)
                {
                    StartCoroutine(TrailEffect());
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

        if (dashing)
        {
            transform.position += transform.up * dashSpeed;
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.clip = dashCutAud;
            audio.Play();
            dashing = false;
        }

    }

    IEnumerator CutEffect()
    {
        Trail.emitting = true;
        HealthScript scr = enemy.GetComponent<HealthScript>();
        Tank.GetComponent<TankScript>().enabled = false;
        yield return new WaitForSeconds(0.5f);
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
        GameObject slashesEffectIns = Instantiate(slashesEffect, enemy.transform.position, Quaternion.identity);
        slashesEffectIns.transform.localScale += new Vector3(1, 1, 1);
        slashesEffectIns.transform.parent = enemy.transform;
        Destroy(slashesEffectIns, 0.9f);
        yield return new WaitForSeconds(0.9f);
        Trail.emitting = false;
        enemy.GetComponent<TankScript>().enabled = true;
        Tank.GetComponent<TankScript>().enabled = true;
        enemy.GetComponentInChildren<FiringScript>().enabled = true;
        if (enemy.name != "KickerTank(Clone)")
        {
            enemy.GetComponentInChildren<FiringScript>().enabled = true;
        }
        else if (enemy.name == "KickerTank(Clone)")
        {
            enemy.GetComponentInChildren<DiableJambe>().enabled = true;
            enemy.GetComponentInChildren<PartyKicks>().enabled = true;
            enemy.GetComponentInChildren<WindBullet>().enabled = true;
            enemy.GetComponentInChildren<Kick>().enabled = true;
        }
    }

    IEnumerator TrailEffect()
    {
        yield return new WaitForSeconds(0.4f);
        Trail.emitting = false;
        yield return new WaitForSeconds(0.5f);
        Trail.emitting = false;
        OffTrail();
        gameObject.GetComponent<TrailRenderer>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<TrailRenderer>().enabled = true;
    }

    private void OffTrail()
    {
        Trail.emitting = false;
        gameObject.GetComponent<TrailRenderer>().emitting = false;
    }
}
