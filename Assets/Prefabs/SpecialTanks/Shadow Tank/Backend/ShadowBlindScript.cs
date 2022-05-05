using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBlindScript : MonoBehaviour
{
    public GameObject ShadowTank; 
    public GameObject Tank;
    private GameObject P1 = GameObject.FindWithTag("Player1");
    private GameObject P2 = GameObject.FindWithTag("Player2");
    public bool BlindCD;
    public float BlindCooldownTimer;
    public GameObject Blind;
    public GameObject EnemyPos;
    public AudioClip BlindSound;
    // Start is called before the first frame update
    void Start()
    {
        BlindCD = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (BlindCD == false && gameObject.GetComponent<TankScript>().isPlayer2Input == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Blind = Instantiate(Blind, P2.transform.position, P2.transform.rotation);
                EnemyPos = Instantiate(EnemyPos, P2.transform.position, P2.transform.rotation);
                AudioSource audio = Tank.GetComponent<AudioSource>();
                audio.clip = BlindSound;
                audio.Play();
                BlindCD = true;
            }
        }


        else
        {
            BlindCooldownTimer -= Time.deltaTime;
        }

        if (BlindCooldownTimer <= 0)
        {
            BlindCD = false;
        }




        if (BlindCD == false && gameObject.GetComponent<TankScript>().isPlayer2Input == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Blind = Instantiate(Blind, P1.transform.position, P1.transform.rotation);
                EnemyPos = Instantiate(EnemyPos, P1.transform.position, P1.transform.rotation);
                AudioSource audio = Tank.GetComponent<AudioSource>();
                audio.clip = BlindSound;
                audio.Play();
                BlindCD = true;
            }
        }


        else
        {
            BlindCooldownTimer -= Time.deltaTime;
        }

        if (BlindCooldownTimer <= 0)
        {
            BlindCD = false;
        }
    }
}
