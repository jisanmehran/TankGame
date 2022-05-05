using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StunTank : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject powerupEffect;
    public GameObject stunEffect;
    public float elapsedTime;
    private float timeamountincrease = 1f;
    private bool Player1Hit;
    private bool Player2Hit;
    private Image cd;

    public bool AlreadyShotBeam = false;

    private GameObject gameManager;

    public GameObject GameControl1;
    public GameObject GameControl2;

    public AudioClip stunsound;

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
            cd = GameControl1.GetComponent<GameControl>().SNTankCDIcon1.GetComponent<Image>();
        }

        if (gameObject.GetComponent<TankScript>().isPlayer2Input == true)
        {
            cd = GameControl2.GetComponent<Game2Control>().SNTankCDIcon2.GetComponent<Image>();
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
                GameObject beamEffectIns = Instantiate(powerupEffect, new Vector2(Player2.transform.position.x, Player2.transform.position.y), Player2.transform.rotation);
                beamEffectIns.transform.parent = Player2.transform;
                Destroy(beamEffectIns, 2f);
                AlreadyShotBeam = true;
                elapsedTime = 0;
                cd.fillAmount = 0;
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = stunsound;
                audio.Play();

                if (Player1Hit == true)
                {
                    GameObject otherhitEffectIns = Instantiate(stunEffect, new Vector2(Player1.transform.position.x, Player1.transform.position.y), Player1.transform.rotation);
                    Destroy(otherhitEffectIns, 5f);
                }

                if (Player1Hit == true)
                {
                    Player1.GetComponent<TankScript>().enabled = false;
                    Invoke("EnablePlayer1Movement", 5f);
                }
            }

            if (AlreadyShotBeam == false & gameObject.GetComponent<TankScript>().isPlayer2Input == false & Input.GetKey(KeyCode.LeftAlt))
            {
                GameObject beamEffectIns = Instantiate(powerupEffect, new Vector2(Player1.transform.position.x, Player1.transform.position.y), Player1.transform.rotation);
                beamEffectIns.transform.parent = Player1.transform;
                Destroy(beamEffectIns, 2f);
                AlreadyShotBeam = true;
                elapsedTime = 0;
                cd.fillAmount = 0;

                if (Player2Hit == true)
                {
                    GameObject otherhitEffectIns = Instantiate(stunEffect, new Vector2(Player2.transform.position.x, Player2.transform.position.y), Player2.transform.rotation);
                    Destroy(otherhitEffectIns, 5f);
                }
                
                if (Player2Hit == true)
                {
                    Player2.GetComponent<TankScript>().enabled = false;
                    Invoke("EnablePlayer2Movement", 5f);
                }
        
            }

        if (elapsedTime >= 10)

        {
            AlreadyShotBeam = false;
        }

        if (AlreadyShotBeam == true)
        {
            cd.fillAmount += Time.deltaTime/10;
        }

    }

    void EnablePlayer1Movement()
    {
        Player1.GetComponent<TankScript>().enabled = true;
    }

    void EnablePlayer2Movement()
    {
        Player2.GetComponent<TankScript>().enabled = true;
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
