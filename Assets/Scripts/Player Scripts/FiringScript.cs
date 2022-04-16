using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringScript : MonoBehaviour
{
    public GameObject bullet;
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    public GameObject Tank; 
    public float speed = 2;
    public bool TripleShot = false;
    public float TSBtw;
    public float bulletSpeed = 10;
    public AudioClip fireSound;
    public CooldownBar CBar;
    public GameObject CDImage;
    public GameObject AccuracyTracker;
    // Start is called before the first frame update

    void Start()
    {
        AccuracyTracker = GameObject.Find("AccuracyTracker");
        Cooldown = false;
        if (Tank.tag == "Player1")
        {
            CDImage = GameObject.FindWithTag("OneCD");
        }
        else
        {
            CDImage = GameObject.FindWithTag("TwoCD");
        }
        
        CBar = CDImage.GetComponent<CooldownBar>();
        CBar.CD = cd;
    }

    // Update is called once per frame
    void Update()
    {
        TankScript scr = Tank.GetComponent<TankScript>();
        if (Cooldown == false && scr.isPlayer2Input == false)
        {
            if (Input.GetKey(KeyCode.LeftControl) && TripleShot == false)
            {  
                Rigidbody2D thebullet = bullet.GetComponent<Rigidbody2D>();
                Cooldown = true;
                timeBtwShots = cd;
                GameObject shotBullet = Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                var destroyTime = 5;
                Destroy (shotBullet, destroyTime);
                AudioSource audio = Tank.GetComponent<AudioSource>();
                audio.clip = fireSound;
                audio.Play();
                AccuracyTracker.GetComponent<Accuracy>().AddShotPlayer1();
            }
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
            CBar.currentCD = timeBtwShots;
            
        }

        if (timeBtwShots <= 0)
        {
            Cooldown = false;
        }

        if (Cooldown == false && scr.isPlayer2Input == true)
        {
            if (Input.GetKey(KeyCode.A) && TripleShot == false)
            {  
                Rigidbody2D thebullet = bullet.GetComponent<Rigidbody2D>();
                Cooldown = true;
                timeBtwShots = cd;
                GameObject shotBullet = Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                var destroyTime = 5;
                Destroy (shotBullet, destroyTime);
                AudioSource audio = Tank.GetComponent<AudioSource>();
                audio.clip = fireSound;
                audio.Play();
                AccuracyTracker.GetComponent<Accuracy>().AddShotPlayer2();
            }  
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
            CBar.currentCD = timeBtwShots;
        }
        
        if (timeBtwShots <= 0)
        {
            Cooldown = false;
        }
    }
}
