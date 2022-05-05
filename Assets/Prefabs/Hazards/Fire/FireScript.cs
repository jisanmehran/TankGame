using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public AudioClip burn;
    public GameObject fireEffect;
    public DiableJambe Dscr;
    public GameObject gameManager;
    public bool DamageOn;
    private float timebtwburns;
    private float cd = 2;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4f);
        gameManager = GameObject.Find("GameManager");
        DamageOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        timebtwburns -= Time.deltaTime;
        if (timebtwburns <= 0)
        {
            DamageOn = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2" && DamageOn == true)
        {
            if (other.gameObject.name == "KickerTank(Clone)")
            {
                return;
            }
            else
            {
                HealthScript scr = other.gameObject.GetComponent<HealthScript>();
                AudioSource audio = other.gameObject.GetComponent<AudioSource>();
                audio.clip = burn;
                audio.Play();
                if (other.gameObject.tag == "Player1")
                {
                    gameManager.GetComponent<gamemanagerscript>().player1hitCount++;
                }
                else
                {
                    gameManager.GetComponent<gamemanagerscript>().player2hitCount++;
                }
                scr.alreadycounted = true;
                scr.Invoke("ResetBullets", 2f);
                GameObject fireEffectIns = Instantiate(fireEffect, transform.position, Quaternion.identity);
                Destroy(fireEffectIns, 0.9f);
                DamageOn = false;
                timebtwburns = cd;
            }
            
        }
    }
}
