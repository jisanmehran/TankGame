using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    public GameObject Master;
    public GameObject Servant;
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    public int ServantNum = 0;
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
            if (Input.GetKey(KeyCode.E) && ServantNum < 3)
            {  
                Cooldown = true;
                timeBtwShots = cd;
                GameObject Summon = Instantiate(Servant, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                ServantNum += 1;
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
