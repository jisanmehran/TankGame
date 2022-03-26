using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class gamemanagerscript : MonoBehaviour
{
    public int player1hitCount;
    public int player2hitCount;
    private GameObject player1;
    private GameObject player2;
    public GameObject deathEffect;
    private bool alreadyspawnedeffect = false;
    private Renderer player1SpriteRender;
    private Renderer player2SpriteRender;



    void Start()
    {
        Invoke("FindSpriteRenderers", 2f);
        Invoke("findplayers", 1f);
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

    // Update is called once per frame
    void Update()
    {
        //Check if player 1 is hit and change the sprites accordingly

        if (player1hitCount == 1)
        {
            player1.GetComponent<SpriteRenderer>().sprite = player1.GetComponent<TankScript>().broken1;
        }

        else if (player1hitCount == 2)
        {
            player1.GetComponent<SpriteRenderer>().sprite = player1.GetComponent<TankScript>().broken2;
        }

        //Check if player 2  is hit and change the sprites accordingly

        if (player2hitCount == 1)
        {
            player2.GetComponent<SpriteRenderer>().sprite = player2.GetComponent<TankScript>().broken1;
        }

        else if (player2hitCount == 2)
        {
            player2.GetComponent<SpriteRenderer>().sprite = player2.GetComponent<TankScript>().broken2;
        }

        //Check is one of the players are dead

        if (player1hitCount == 3)
        {
            if (alreadyspawnedeffect == false)
            {
                CameraShaker.Instance.ShakeOnce(5, 5, 0.2f, 1f);
                player1.GetComponent<TankScript>().enabled = false;
                player1.GetComponentInChildren<FiringScript>().enabled = false;
                GameObject deathEffectIns = Instantiate(deathEffect, player1.transform.position, Quaternion.identity);
                Destroy(deathEffectIns, 2f);
                Invoke("loadPlayAgainScreen2", 3f);
                Invoke("destroyGameManager", 3f);
                alreadyspawnedeffect = true;
            }
        }

        else if (player2hitCount == 3)
        {
            if (alreadyspawnedeffect == false)
            {
                CameraShaker.Instance.ShakeOnce(5, 5, 0.2f, 1f);
                player2.GetComponent<TankScript>().enabled = false;
                player2.GetComponentInChildren<FiringScript>().enabled = false;
                GameObject deathEffectIns = Instantiate(deathEffect, player2.transform.position, Quaternion.identity);
                Destroy(deathEffectIns, 2f);
                Invoke("loadPlayAgainScreen", 3f);
                Invoke("destroyGameManager", 3f);
                alreadyspawnedeffect = true;
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
}
