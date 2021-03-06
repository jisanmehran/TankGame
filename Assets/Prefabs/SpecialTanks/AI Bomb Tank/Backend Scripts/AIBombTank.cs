using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIBombTank : MonoBehaviour
{
    private GameObject UIController;
    public GameObject Master;
    public GameObject droneLaunchEffect;
    public GameObject Servant;
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    public int ServantNum = 0;
    public AudioClip bombSpawn;
    public CooldownBar CBar;
    public GameObject CDImage;
    private bool alreadyresetbombtime;

    // Start is called before the first frame update
    void Start()
    {
        UIController = GameObject.Find("UICooldownController");
        Cooldown = false;
        if (Master.tag == "Player1")
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
        TankScript scr = gameObject.GetComponent<TankScript>();
        if (Cooldown == false && scr.isPlayer2Input == false)
        {
            if (Input.GetKey(KeyCode.LeftAlt) | Input.GetKey(KeyCode.RightAlt) && ServantNum < 3)
            {  
                Cooldown = true;
                timeBtwShots = cd;
                GameObject Summon = Instantiate(Servant, new Vector2(transform.position.x, transform.position.y), transform.rotation);

                if (alreadyresetbombtime == false)
                {
                    Summon.GetComponent<EnemyShootingAI>().elapsedTime = 0;
                    Summon.GetComponent<EnemyShootingAI>().overtimelimit = true;
                    alreadyresetbombtime = true;
                    Invoke("ResetBombCooldown", 10f);
                    Invoke("ResetCooldown", 10f);
                    UIController.GetComponent<UIAbilitiesScript>().triggercooldown1P1 = true;
                }

                Summon.GetComponent<EnemyShootingAI>().overtimelimit = true;
                GameObject tmpeffect = Instantiate(droneLaunchEffect, Summon.transform.position, Quaternion.identity);
                Destroy(tmpeffect, 1f);    
                ServantNum += 1;
                AudioSource audio = Master.GetComponent<AudioSource>();
                audio.clip = bombSpawn;
                audio.Play();

            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
            CBar.currentCD = timeBtwShots;
        }

        if (Cooldown == false && scr.isPlayer2Input == true)
        {
            if (Input.GetKey(KeyCode.S) && ServantNum < 3)
            {  
                Cooldown = true;
                timeBtwShots = cd;
                GameObject Summon = Instantiate(Servant, new Vector2(transform.position.x, transform.position.y), transform.rotation);

                if (alreadyresetbombtime == false)
                {
                    Summon.GetComponent<EnemyShootingAI>().elapsedTime = 0;
                    Summon.GetComponent<EnemyShootingAI>().overtimelimit = true;
                    alreadyresetbombtime = true;
                    Invoke("ResetBombCooldown", 10f);
                    Invoke("ResetCooldown", 10f);
                    UIController.GetComponent<UIAbilitiesScript>().triggercooldown1P2 = true;
                }

                GameObject tmpeffect = Instantiate(droneLaunchEffect, Summon.transform.position, Quaternion.identity);
                Destroy(tmpeffect, 1f);                
                ServantNum += 1;
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = bombSpawn;
                audio.Play();
            }  
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
            CBar.currentCD = timeBtwShots;
        }
    }

    void ResetBombCooldown()
    {
        alreadyresetbombtime = false;
    }
    void ResetCooldown()
    {
        Cooldown = false;
    }
}
