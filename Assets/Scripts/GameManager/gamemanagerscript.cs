using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class gamemanagerscript : MonoBehaviour
{
    //Handle Game Exit Variables
    public float holdTime = 3.0f; // how long you need to hold to trigger the effect
 
    private float startTime = 0f;
    private float timer = 0f;
 
    // Use if you only want to call the method once after holding for the required time
    private bool held = false;

    //Game Varaibles
    public int player1hitCount;
    public int player2hitCount;
    private GameObject player1;
    private GameObject player2;
    public GameObject deathEffect;
    private bool alreadyspawnedeffect = false;
    private Renderer player1SpriteRender;
    private Renderer player2SpriteRender;
    private GameObject player1heart1;
    private GameObject player1heart2;
    private GameObject player1heart3;
    private GameObject player2heart1;
    private GameObject player2heart2;
    private GameObject player2heart3;
    public GameObject AccuracyTracker;
    public AudioClip deathsound;




    void Start()
    {
        AccuracyTracker = GameObject.Find("AccuracyTracker");
        Invoke("FindSpriteRenderers", 2f);
        Invoke("findplayers", 2f);
        Invoke("findSprites", 1f);
    }

    void FindSpriteRenderers()
    {
        player1SpriteRender = player1.GetComponent<SpriteRenderer>();
        player2SpriteRender = player2.GetComponent<SpriteRenderer>();
    }

    void findplayers()
    {
        player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");
    }

    void findSprites()
    {
        player1heart1 = GameObject.Find("P1Heart1");
        player1heart2 = GameObject.Find("P1Heart2");
        player1heart3 = GameObject.Find("P1Heart3");

        player2heart1 = GameObject.Find("P2Heart1");
        player2heart2 = GameObject.Find("P2Heart2");
        player2heart3 = GameObject.Find("P2Heart3");

    }

    // Update is called once per frame
    void Update()
    {
        //Handle OngameExit
        HandleGameExit();

        //Check if player 1 is hit and change the sprites accordingly

        if (player1hitCount == 1)
        {
            if (player1.name != "One's Greatest High(Clone)")
            {
                player1.GetComponent<SpriteRenderer>().sprite = player1.GetComponent<TankScript>().broken1;
            } 
            player1heart3.SetActive(false);
        }

        else if (player1hitCount == 2)
        {
            if (player1.name != "One's Greatest High(Clone)")
            {
                player1.GetComponent<SpriteRenderer>().sprite = player1.GetComponent<TankScript>().broken2;
            }
            player1heart2.SetActive(false);
        }

        //Check if player 2  is hit and change the sprites accordingly

        if (player2hitCount == 1)
        {
            if (player2.name != "One's Greatest High(Clone)")
            {
                player2.GetComponent<SpriteRenderer>().sprite = player2.GetComponent<TankScript>().broken1;
            }
            player2heart3.SetActive(false);
        }

        else if (player2hitCount == 2)
        {
            if (player1.name != "One's Greatest High(Clone)")
            {
                player2.GetComponent<SpriteRenderer>().sprite = player2.GetComponent<TankScript>().broken2;
            }
            player2heart2.SetActive(false);
        }

        //Check is one of the players are dead

        if (player1hitCount == 3)
        {
            if (alreadyspawnedeffect == false)
            {
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = deathsound;
                audio.Play();
                CameraShaker.Instance.ShakeOnce(5, 5, 0.2f, 1f);
                player1.GetComponent<TankScript>().enabled = false;
                player1.GetComponentInChildren<FiringScript>().enabled = false;
                GameObject deathEffectIns = Instantiate(deathEffect, player1.transform.position, Quaternion.identity);
                Destroy(deathEffectIns, 2f);
                Invoke("loadPlayAgainScreen2", 3f);
                Invoke("destroyGameManager", 3f);
                alreadyspawnedeffect = true;
                player1heart1.SetActive(false);
                DontDestroyOnLoad(AccuracyTracker);
            }
        }

        else if (player2hitCount == 3)
        {
            if (alreadyspawnedeffect == false)
            {
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = deathsound;
                audio.Play();
                CameraShaker.Instance.ShakeOnce(5, 5, 0.2f, 1f);
                player2.GetComponent<TankScript>().enabled = false;
                player2.GetComponentInChildren<FiringScript>().enabled = false;
                GameObject deathEffectIns = Instantiate(deathEffect, player2.transform.position, Quaternion.identity);
                Destroy(deathEffectIns, 2f);
                Invoke("loadPlayAgainScreen", 3f);
                Invoke("destroyGameManager", 3f);
                alreadyspawnedeffect = true;
                player2heart1.SetActive(false);
                DontDestroyOnLoad(AccuracyTracker);
            }
        }        
    }

    void destroyGameManager()
    {
        Destroy(gameObject);
    }

    void loadPlayAgainScreen()
    {
        SceneManager.LoadScene("PlayAgain");
    }

    void loadPlayAgainScreen2()
    {
        SceneManager.LoadScene("PlayAgain2");
    }

    private void HandleGameExit()
    {
        string key = "escape";

        // Starts the timer from when the key is pressed
        if (Input.GetKeyDown(key))
        {
            startTime = Time.time;
            timer = startTime;
        }
 
        // Adds time onto the timer so long as the key is pressed
        if (Input.GetKey(key) && held == false)
        {
            timer += Time.deltaTime;
 
            // Once the timer float has added on the required holdTime, changes the bool (for a single trigger), and calls the function
            if (timer > (startTime + holdTime))
            {
                held = true;
                EscapeButtonHeld();
            }
        }
 
        // For single effects. Remove if not needed
        if (Input.GetKeyUp(key))
        {
            held = false;
        }
    
    }
        void EscapeButtonHeld()
    {
        Debug.Log("held for " + holdTime + " seconds");
        Application.Quit();
    }
}
