using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBullet : MonoBehaviour
{
    public GameObject windbullet;
    public GameObject flamingwindbullet;
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    private GameObject Tank; 
    public float speed = 2;
    public float bulletSpeed = 10;
    public AudioClip fireSound;
    private Animator anim;
    private GameObject enemy;
    // Start is called before the first frame update

    void Start()
    {
        Tank = GameObject.Find("KickerTank(Clone)");
        anim = Tank.GetComponent<Animator>();
        Cooldown = false;
        if (Tank.tag == "Player1")
        {
            enemy = GameObject.FindWithTag("Player2");
        }
        else
        {
            enemy = GameObject.FindWithTag("Player1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        TankScript scr = Tank.GetComponent<TankScript>();
        if (Cooldown == false && scr.isPlayer2Input == false)
        {
            if (Input.GetKey(KeyCode.LeftAlt))
            {  
                anim.SetTrigger("WindKick");
                DiableJambe Dscr = Tank.GetComponent<DiableJambe>();
                if (Dscr.DiableLeg == true)
                {
                    Rigidbody2D fbullet = flamingwindbullet.GetComponent<Rigidbody2D>();
                    GameObject flamingwindBullet = Instantiate(flamingwindbullet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                    var destroyTime = 3;
                    Destroy(flamingwindBullet, destroyTime);
                }
                else if (Dscr.DiableLeg == false)
                {
                    Rigidbody2D wbullet = windbullet.GetComponent<Rigidbody2D>();
                    GameObject windBullet = Instantiate(windbullet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                    var destroyTime = 3;
                    Destroy(windBullet, destroyTime);
                }
                Cooldown = true;
                timeBtwShots = cd;
                AudioSource audio = Tank.GetComponent<AudioSource>();
                audio.clip = fireSound;
                audio.Play();
            }
        }
        else if (Cooldown == false && scr.isPlayer2Input == true)
        {
            if (Input.GetKey(KeyCode.S))
            {  
                anim.SetTrigger("WindKick");
                DiableJambe Dscr = Tank.GetComponent<DiableJambe>();
                if (Dscr.DiableLeg == true)
                {
                    Rigidbody2D fbullet = flamingwindbullet.GetComponent<Rigidbody2D>();
                    GameObject flamingwindBullet = Instantiate(flamingwindbullet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                    var destroyTime = 3;
                    Destroy(flamingwindBullet, destroyTime);
                }
                else if (Dscr.DiableLeg == false)
                {
                    Rigidbody2D wbullet = windbullet.GetComponent<Rigidbody2D>();
                    GameObject windBullet = Instantiate(windbullet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                    var destroyTime = 3;
                    Destroy(windBullet, destroyTime);
                }
                Cooldown = true;
                timeBtwShots = cd;
                AudioSource audio = Tank.GetComponent<AudioSource>();
                audio.clip = fireSound;
                audio.Play();
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
