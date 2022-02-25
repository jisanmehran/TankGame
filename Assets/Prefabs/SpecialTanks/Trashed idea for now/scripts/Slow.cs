using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject Effect1;
    public bool Active;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Cooldown == false)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Effect1.SetActive(true);
                Active = true;
                Cooldown = true;
                timeBtwShots = cd;
                foreach(var GameObject in enemies)
                {
                    if (GameObject.CompareTag("Tank"))
                    {
                        TankScript scr = GameObject.GetComponent<TankScript>();
                        scr.moveAcceleration = 0.5f;
                        scr.rotateAcceleration = 0.5f;
                        scr.moveSpeedMax = 1.25f;
                        scr.rotateSpeedMax = 65f;
                    }
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
        else if (timeBtwShots <= 3)
        {
            Effect1.SetActive(false);
            Active = false;
            foreach(var GameObject in enemies)
            {
                if (GameObject.CompareTag("Tank"))
                {
                    TankScript scr = GameObject.GetComponent<TankScript>();
                    scr.moveAcceleration = 1f;
                    scr.rotateAcceleration = 8f;
                    scr.moveSpeedMax = 5f;
                    scr.rotateSpeedMax = 170f;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name != "PauseTank")
        {
            if (other.gameObject.name != "Bullet(Clone)")  
            {
                enemies.Add(other.gameObject);
                if (Active == true)
                {
                    TankScript scr = other.gameObject.GetComponent<TankScript>();
                    scr.moveAcceleration = 0.5f;
                    scr.rotateAcceleration = 0.5f;
                    scr.moveSpeedMax = 1.25f;
                    scr.rotateSpeedMax = 65f;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name != "PauseTank")
        {
            enemies.Remove(other.gameObject);
            TankScript scr = other.gameObject.GetComponent<TankScript>();
            scr.moveAcceleration = 1f;
            scr.rotateAcceleration = 8f;
            scr.moveSpeedMax = 5f;
            scr.rotateSpeedMax = 170f;
        }
    }
}
