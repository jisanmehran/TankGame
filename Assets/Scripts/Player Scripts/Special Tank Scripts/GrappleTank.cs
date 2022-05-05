using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrappleTank : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject beamEffect;
    public GameObject otherhitEffect;
    public float elapsedTime = 12f;
    private float timeamountincrease = 1f;
    private bool Player1Hit;
    private bool Player2Hit;
    private Image cd;

    public GameObject GameControl1;
    public GameObject GameControl2;
    public AudioClip beamsound;
    public bool AlreadyShotBeam = false;

    private GameObject gameManager;
    void Start()
    {
        AlreadyShotBeam = false;
        gameManager = GameObject.Find("GameManager");
        Invoke("FindPlayers", 2f);
        Invoke("FindSpritesCD", 2f);
        Invoke("FindGameControls", 1.5f);
    }

    void FindSpritesCD()
    {
        if (gameObject.GetComponent<TankScript>().isPlayer2Input == false)
        {
            cd = GameControl1.GetComponent<GameControl>().BMTankCDIcon1.GetComponent<Image>();
        }

        if (gameObject.GetComponent<TankScript>().isPlayer2Input == true)
        {
            cd = GameControl2.GetComponent<Game2Control>().BMTankCDIcon2.GetComponent<Image>();
        }
    }

    void FindGameControls()
    {
        GameControl1 = GameObject.Find("GameControl");
        GameControl2 = GameObject.Find("GameControl Player 2");
    }
    void Update()
    {
        elapsedTime += timeamountincrease * Time.deltaTime;

            if (AlreadyShotBeam == false & gameObject.GetComponent<TankScript>().isPlayer2Input == true & Input.GetKeyDown(KeyCode.S))
            {
                GameObject beamEffectIns = Instantiate(beamEffect, new Vector2(Player2.transform.position.x, Player2.transform.position.y), Player2.transform.rotation);
                Destroy(beamEffectIns, 0.9f);
                AlreadyShotBeam = true;
                elapsedTime = 0;
                cd.fillAmount = 0;

                if (Player1Hit == true)
                {
                    GameObject otherhitEffectIns = Instantiate(otherhitEffect, new Vector2(Player1.transform.position.x, Player1.transform.position.y), Player1.transform.rotation);
                }

                if (Player1Hit == true)
                {
                    gameManager.GetComponent<gamemanagerscript>().player1hitCount++;
                }
            }

            if (AlreadyShotBeam == false & gameObject.GetComponent<TankScript>().isPlayer2Input == false & Input.GetKey(KeyCode.LeftAlt))
            {
                GameObject beamEffectIns = Instantiate(beamEffect, new Vector2(Player1.transform.position.x, Player1.transform.position.y), Player1.transform.rotation);
                Destroy(beamEffectIns, 0.9f);
                AlreadyShotBeam = true;
                elapsedTime = 0;
                cd.fillAmount = 0;
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = beamsound;
                audio.Play();

                if (Player2Hit == true)
                {
                    GameObject otherhitEffectIns = Instantiate(otherhitEffect, new Vector2(Player2.transform.position.x, Player2.transform.position.y), Player2.transform.rotation);
                }
                
                if (Player2Hit == true)
                {
                    gameManager.GetComponent<gamemanagerscript>().player2hitCount++;
                }
        
            }

        if (elapsedTime >= 15)

        {
            AlreadyShotBeam = false;
        }

        if (AlreadyShotBeam == true)
        {
            cd.fillAmount += Time.deltaTime/15;
        }
    }

    void FindPlayers()
    {
        Player1 = GameObject.FindWithTag("Player1");
        Player2 = GameObject.FindWithTag("Player2");
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if((other.tag == "Player1"))
        {
            Player1Hit = true;
        }

        if ((other.tag == "Player2"))
        {
            Player2Hit = true;
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if((other.tag == "Player1"))
        {
            Player1Hit = false;
        }

        if ((other.tag == "Player2"))
        {
            Player2Hit = false;
        }

    }

}
