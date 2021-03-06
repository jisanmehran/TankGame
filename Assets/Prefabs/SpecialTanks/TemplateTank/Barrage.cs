using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage : MonoBehaviour
{
    public GameObject BarrageHit;
    public GameObject FirePoint;
    public bool Cooldown;
    public GameObject Tank;
    private float timeBtwShots;
    public float cd;
    public int punchnumber;
    // Start is called before the first frame update
    void Start()
    {
        Cooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        TankScript scr = Tank.GetComponent<TankScript>();
        if (Cooldown == false && scr.isPlayer2Input == false)
        {
            while (Input.GetButton("Fire2") && punchnumber < 7)
            {  
                GameObject Punch = Instantiate(BarrageHit, new Vector2(FirePoint.transform.position.x, FirePoint.transform.position.y), transform.rotation);
                punchnumber += 1;
                Destroy(Punch,0.5f);
            }
            Cooldown = true;
            punchnumber = 0;
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
            while (Input.GetKey(KeyCode.S) && punchnumber < 7)
            {  
                GameObject Punch = Instantiate(BarrageHit, new Vector2(FirePoint.transform.position.x, FirePoint.transform.position.y), transform.rotation);
                punchnumber += 1;
                Destroy(Punch,0.5f);
            }
            Cooldown = true;
            punchnumber = 0; 
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
