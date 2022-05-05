using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoSpawn : MonoBehaviour
{
    public GameObject Tornado;
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    public GameObject Tank;
    public GameObject inputdetector; 
    public TankScript isPlayer2Input;
    public AudioClip spawnsound;
    private Animator anim;
    // Start is called before the first frame update

    void Start()
    {
        inputdetector = GameObject.Find("GameControl");
        Cooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        TankScript scr = Tank.GetComponent<TankScript>();
        if (Cooldown == false)
        { 
            if (Input.GetKeyDown(KeyCode.Space) && gameObject.GetComponent<TankScript>().isPlayer2Input == false)
            {  
                Rigidbody2D theTornado = Tornado.GetComponent<Rigidbody2D>();
                Cooldown = true;
                timeBtwShots = cd;
                GameObject shotTornado = Instantiate(Tornado, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                AudioSource audio = Tank.GetComponent<AudioSource>();
                audio.clip = spawnsound;
                audio.Play();
            }
            if (Input.GetKey(KeyCode.Q) && gameObject.GetComponent<TankScript>().isPlayer2Input == true)
            {
                Rigidbody2D theTornado = Tornado.GetComponent<Rigidbody2D>();
                Cooldown = true;
                timeBtwShots = cd;
                GameObject shotTornado = Instantiate(Tornado, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                AudioSource audio = Tank.GetComponent<AudioSource>();
                audio.clip = spawnsound;
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
