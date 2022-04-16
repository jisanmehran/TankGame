using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{ 
    private Scene scene;
    private GameObject gameManager;
    public bool alreadycounted;
    public GameObject hitEffect;
    public AudioClip hitsound;
    public GameObject AccuracyTracker;

    void Start()
    {
        AccuracyTracker = GameObject.Find("AccuracyTracker");
        gameManager = GameObject.Find("GameManager");
        scene = SceneManager.GetActiveScene();
        alreadycounted = false;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet" && gameObject.tag == "Player1" && alreadycounted == false)
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.clip = hitsound;
            audio.Play();
            player1deathiterator();
            alreadycounted = true;
            Invoke("ResetBullets", 2f);
            Destroy(other.gameObject);
            GameObject hitEffectIns = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(hitEffectIns, 0.9f);
            AccuracyTracker.GetComponent<Accuracy>().shots_hit_player1++;
        }
        
        if (other.gameObject.tag == "Bullet" && gameObject.tag == "Player2" && alreadycounted == false)
        {   
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.clip = hitsound;
            audio.Play();
            player2deathiterator();
            alreadycounted = true;
            Invoke("ResetBullets", 2f);
            Destroy(other.gameObject);
            GameObject hitEffectIns = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(hitEffectIns, 0.9f);
            AccuracyTracker.GetComponent<Accuracy>().shots_hit_player2++;
        }

        if (other.gameObject.tag == "Bullet" && gameObject.tag == "Player1" && alreadycounted == true)
        {   
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Bullet" && gameObject.tag == "Player2" && alreadycounted == true)
        {   
            Destroy(other.gameObject);
        }
    }

    public void player1deathiterator()
    {
        DontDestroyOnLoad(gameManager);
        gameManager.GetComponent<gamemanagerscript>().player1hitCount += 1;
        
    }

    void ResetBullets()
    {
        alreadycounted = false;
    }

    public void player2deathiterator()
    {
        DontDestroyOnLoad(gameManager);
        gameManager.GetComponent<gamemanagerscript>().player2hitCount += 1;
        
    }

    void reloadScene()
    {
        SceneManager.LoadScene(scene.name);
    }
}
