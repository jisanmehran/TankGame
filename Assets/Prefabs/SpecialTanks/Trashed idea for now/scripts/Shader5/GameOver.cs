using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
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
    public TankScript isPlayer2Input;
    public Camera m_MainCamera;
    public bool Serious = false;
    // Start is called before the first frame update

    void Start()
    {
        Cooldown = false;
        m_MainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        TankScript scr = Tank.GetComponent<TankScript>();
        if (Cooldown == false & scr.isPlayer2Input == false)
        {
            if (Serious)
            {  
                Rigidbody2D thebullet = bullet.GetComponent<Rigidbody2D>();
                Cooldown = true;
                timeBtwShots = cd;
                GameObject shotBullet = Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                m_MainCamera = Camera.main;
                Camera.main.GetComponent<PostProcess>().enabled = true;
                m_MainCamera.GetComponent<PostProcess>().enabled = true;
                Debug.Log("here");
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

        if (Cooldown == false & scr.isPlayer2Input == true)
        {
            if (Serious)
            {  
                Rigidbody2D thebullet = bullet.GetComponent<Rigidbody2D>();
                Cooldown = true;
                timeBtwShots = cd;
                GameObject shotBullet = Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                m_MainCamera = Camera.main;
                Camera.main.GetComponent<PostProcess>().enabled = true;
                m_MainCamera.GetComponent<PostProcess>().enabled = true;
                Debug.Log("here2");
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
