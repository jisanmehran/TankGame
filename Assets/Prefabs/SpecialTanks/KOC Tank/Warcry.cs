using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warcry : MonoBehaviour
{
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    public GameObject inputdetector;
    private GameObject enemy;
    private GameObject King;
    public AudioClip thecry;
    // Start is called before the first frame update
    void Start()
    {
        inputdetector = GameObject.Find("GameControl");
        King = GameObject.Find("KingOC Tank(Clone)");
        if (King.tag == "Player1")
        {
            enemy = GameObject.FindWithTag("Player2");
        }
        else if (King.tag == "Player2")
        {
            enemy = GameObject.FindWithTag("Player1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Cooldown == false)
        {
            if (Input.GetKey(KeyCode.S) && gameObject.GetComponent<TankScript>().isPlayer2Input == true)
            { 
                StartCoroutine(Stun());
                Cooldown = true;
                timeBtwShots = cd;
                AudioSource audio = King.GetComponent<AudioSource>();
                audio.clip = thecry;
                audio.Play();  
            }

            if (Input.GetKeyDown(KeyCode.LeftAlt) | Input.GetKey(KeyCode.RightAlt) && gameObject.GetComponent<TankScript>().isPlayer2Input == false)
            {
                StartCoroutine(Stun());
                Cooldown = true;
                timeBtwShots = cd;
                AudioSource audio = King.GetComponent<AudioSource>();
                audio.clip = thecry;
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

    IEnumerator Stun()
    {
        Debug.Log("started");
        enemy.GetComponent<TankScript>().enabled = false;
        enemy.GetComponentInChildren<FiringScript>().enabled = false;
        yield return new WaitForSeconds(1);
        enemy.GetComponent<TankScript>().enabled = true;
        enemy.GetComponentInChildren<FiringScript>().enabled = true;
        Debug.Log("ended");
    }
}
