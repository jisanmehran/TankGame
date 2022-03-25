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
    public AudioClip summon;
    public CooldownBar CBar;
    public GameObject CDImage;
    // Start is called before the first frame update
    void Start()
    {
        Cooldown = false;
        if (gameObject.tag == "Player1")
        {
            CDImage = GameObject.FindWithTag("OneFireOneCD");
        }
        else
        {
            CDImage = GameObject.FindWithTag("TwoFireOneCD");
        }
        
        CBar = CDImage.GetComponent<CooldownBar>();
        CBar.CD = cd;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cooldown == false)
        {
            if (Input.GetKey(KeyCode.S) && gameObject.GetComponent<TankScript>().isPlayer2Input == true && ServantNum < 3)
            {  
                Cooldown = true;
                timeBtwShots = cd;
                GameObject Summon = Instantiate(Servant, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                ServantNum += 1;
                AudioSource audio = Master.GetComponent<AudioSource>();
                audio.clip = summon;
                audio.Play();          
            }

            if (Input.GetKey(KeyCode.LeftAlt) | Input.GetKey(KeyCode.RightAlt) && gameObject.GetComponent<TankScript>().isPlayer2Input == false && ServantNum < 3)
            {  
                Cooldown = true;
                timeBtwShots = cd;
                GameObject Summon = Instantiate(Servant, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                ServantNum += 1;
                AudioSource audio = Master.GetComponent<AudioSource>();
                audio.clip = summon;
                audio.Play();          
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
