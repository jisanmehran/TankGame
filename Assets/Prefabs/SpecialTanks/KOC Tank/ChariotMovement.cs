using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChariotMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed = 20;
    private Vector3 direction;
    public AudioClip flysound;
    public AudioClip crashsound;
    public AudioClip flydownsound;
    private GameObject enemy;
    private GameObject King;
    public GameObject hitEffect;
    private bool moving = true;
    private bool shrink = false;
    public Vector3 scaleChange = new Vector3(-0.0025f, -0.0025f, -0.0025f);
    void Start()
    {
        King = GameObject.Find("KingOC Tank(Clone)");
        if (King.tag == "Player1")
        {
            enemy = GameObject.FindWithTag("Player2");
        }
        else if (King.tag == "Player2")
        {
            enemy = GameObject.FindWithTag("Player1");
        }
        rb = GetComponent<Rigidbody2D>();
        direction = transform.up;
    }
 
    // Update is called once per frame
    void Update()
    {
        if (moving == true)
        {
            rb.velocity = direction * bulletSpeed;
            float rotationz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotationz - 90);
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.clip = flysound;
            audio.Play();
        } 

        if (shrink == true)
        {
            gameObject.transform.localScale += scaleChange;
        }   
    }

    void FixedUpdate()
    {
        Destroy(gameObject, 5f);
    }
 
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == enemy.name)
        {
            StartCoroutine(Drop());
            enemy.GetComponent<TankScript>().enabled = false;
            enemy.GetComponentInChildren<FiringScript>().enabled = false;
        }
    }

    IEnumerator Drop()
    {
        yield return new WaitForSeconds(0.1f);

        rb.velocity = new Vector2(0,0); 
        shrink = true;
        moving = false;
        HealthScript scr = enemy.GetComponent<HealthScript>();
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.clip = flydownsound;
        audio.Play();
        scr.enabled = false;

        yield return new WaitForSeconds(1);

        scr.enabled = true;
        shrink = false;
        audio.clip = crashsound;
        audio.Play();
        if (enemy.tag == "Player1")
        {
            scr.player1deathiterator();
        }
        else
        {
            scr.player2deathiterator();
        }
        scr.alreadycounted = true;
        scr.Invoke("ResetBullets", 2f);
        GameObject hitEffectIns = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(hitEffectIns, 0.9f);
        //Chariot crash effect
        //GameObject hitEffectIns = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(hitEffectIns, 0.9f);
        enemy.GetComponent<TankScript>().enabled = true;
        enemy.GetComponentInChildren<FiringScript>().enabled = true;
        Destroy(this.gameObject);
    }
}
