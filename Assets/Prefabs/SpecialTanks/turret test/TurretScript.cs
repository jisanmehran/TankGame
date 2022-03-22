using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    private const bool V = false;
    public float Range;
    public Transform Target;
    bool Detected = false;
    Vector2 Direction;
    public GameObject AlarmLight;
    public GameObject Barrel;
    public GameObject Turret;

    public GameObject bullet;
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    public float speed = 2;
    public float bulletSpeed = 10;
    public AudioClip fireSound;
    private GameObject Player1;
    private GameObject Player2;
    public LayerMask Ignore;
    
    // Start is called before the first frame update
    void Awake()
    {
        Player1 = GameObject.FindGameObjectWithTag("Player1");
        Player2 = GameObject.FindGameObjectWithTag("Player2");
        if (Player1.name == "SummonerTank(Clone)")
        {
            
            Target = Player2.transform;
        }
        else
        {
            Target = Player1.transform;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;

        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y),Direction,Range,~Ignore);

        if(rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Player1" && rayInfo.collider.gameObject.name != "SummonerTank(Clone)")
            {
                if(Detected == false)
                {
                    Detected = true;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
            else if(rayInfo.collider.gameObject.tag == "Player2" && rayInfo.collider.gameObject.name != "SummonerTank(Clone)")
            {
                if(Detected == false)
                {
                    Detected = true;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
        }
        else
        {
            if (Detected == true)
            {
                Detected = false;
                AlarmLight.GetComponent<SpriteRenderer>().color = Color.green;
                Cooldown = false;
                timeBtwShots = 0;
            }    
        }

        if (Detected)
        {
            Turret.transform.up = Direction;
            if (Cooldown == false)
            {
                Rigidbody2D thebullet = bullet.GetComponent<Rigidbody2D>();
                Cooldown = true;
                timeBtwShots = cd;
                GameObject shotBullet = Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                var destroyTime = 5;
                Destroy (shotBullet, destroyTime);
                AudioSource audio = Turret.GetComponent<AudioSource>();
                audio.clip = fireSound;
                audio.Play();
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
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,Range);
    }
}
