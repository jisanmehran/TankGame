using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBombTank : MonoBehaviour
{

    public GameObject Master;
    public GameObject Servant;
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    public int ServantNum = 0;
    public AudioClip bombSpawn;
    // Start is called before the first frame update
    void Start()
    {
        Cooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        TankScript scr = gameObject.GetComponent<TankScript>();
        if (Cooldown == false && scr.isPlayer2Input == false)
        {
            if (Input.GetKey(KeyCode.LeftAlt) | Input.GetKey(KeyCode.RightAlt) && ServantNum < 2)
            {  
                Cooldown = true;
                timeBtwShots = cd;
                GameObject Summon = Instantiate(Servant, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                ServantNum += 1;
                AudioSource audio = Master.GetComponent<AudioSource>();
                audio.clip = bombSpawn;
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

        if (Cooldown == false && scr.isPlayer2Input == true)
        {
            if (Input.GetKey(KeyCode.S) && ServantNum < 2)
            {  
                Cooldown = true;
                timeBtwShots = cd;
                GameObject Summon = Instantiate(Servant, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                ServantNum += 1;
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = bombSpawn;
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
