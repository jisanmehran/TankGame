using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed = 5;
    private Vector3 direction;
    public AudioClip tornadosound;
    private GameObject enemy;
    private GameObject Tank;
    public GameObject hitEffect;
    public LayerMask WallLayer;
    public GameObject gameManager;
    public bool alreadyDamaged;
    void Start()
    {
        alreadyDamaged = false;
        Tank = GameObject.Find("LightsaberTank(Clone)");
        if (Tank.tag == "Player1")
        {
            enemy = GameObject.FindWithTag("Player2");
        }
        else if (Tank.tag == "Player2")
        {
            enemy = GameObject.FindWithTag("Player1");
        }
        rb = GetComponent<Rigidbody2D>();
        print(enemy);
        direction = transform.up;
        gameManager = GameObject.Find("GameManager");
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * bulletSpeed;
        float rotationz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationz - 90);
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.clip = tornadosound;
        audio.Play(); 
    }

    void FixedUpdate()
    {
        Destroy(gameObject, 15f);
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == enemy.name)
        {
            HealthScript scr = enemy.GetComponent<HealthScript>();
            if (enemy.tag == "Player1" & alreadyDamaged == false)
            {
                gameManager.GetComponent<gamemanagerscript>().player1hitCount++;
                alreadyDamaged = true;
                Invoke("TurnOffAlreadyDamaged", 3f);
            }
            else
            {
                gameManager.GetComponent<gamemanagerscript>().player2hitCount++;
                alreadyDamaged = true;
                Invoke("TurnOffAlreadyDamaged", 3f);
            }
            scr.alreadycounted = true;
            scr.Invoke("ResetBullets", 2f);
            GameObject hitEffectIns = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(hitEffectIns, 0.9f);
        } 
    }

    private void TurnOffAlreadyDamaged()
    {
        alreadyDamaged = false;
    }

    
}
