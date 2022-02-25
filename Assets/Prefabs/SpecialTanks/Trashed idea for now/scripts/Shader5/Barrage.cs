using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage : MonoBehaviour
{
    public GameObject BarrageHit;
    public bool Cooldown;
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
        if (Cooldown == false)
        {
            while (Input.GetButton("Fire2"))
            {  
                if (punchnumber == 6)
                {
                    punchnumber -= 1;

                }
                else
                {
                    GameObject Punch = Instantiate(BarrageHit, new Vector2(transform.position.x, transform.position.y+0.5f), transform.rotation);
                    punchnumber += 1;
                    Destroy(Punch,0.5f);
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
    }
}
