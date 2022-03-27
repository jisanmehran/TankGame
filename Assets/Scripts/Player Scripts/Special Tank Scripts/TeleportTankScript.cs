
using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class TeleportTankScript : MonoBehaviour

{

    //Variables

    public GameObject TankCollider;

    public bool TeleportEnabled;

    public float elapsedTime;

    private float timeamountincrease = 1f;

    public AudioClip phase;

    public SpriteRenderer Render;

    public bool Cooldown;

    private float timeBtwShots;

    public float cd;

    public CooldownBar CBar;

    public GameObject CDImage;
    private GameObject UIController;
    void Start()
    {
        UIController = GameObject.Find("UICooldownController");
        Cooldown = false;
        if (gameObject.tag == "Player1")
        {
            CDImage = GameObject.FindWithTag("OneFireOneCD");
        }
        else
        {
            CDImage = GameObject.FindWithTag("TwoFireOneCD");
        }
        
        CBar = CDImage.GetComponent<CooldownBar>();
        CBar.CD = cd;
    }
    private void Update()

    {
        if (Cooldown == false)
        {
            if (Input.GetKey(KeyCode.LeftAlt) | Input.GetKey(KeyCode.RightAlt) && gameObject.GetComponent<TankScript>().isPlayer2Input == false)
            {
                Cooldown = true;
                UIController.GetComponent<UIAbilitiesScript>().triggercooldown2P1 = true;
                timeBtwShots = cd;
                
                TeleportEnabled = true;
            
                elapsedTime = 0;
        
                AudioSource audio = TankCollider.GetComponent<AudioSource>();
                audio.clip = phase;
                audio.Play();
            }

            if (Input.GetKeyDown(KeyCode.S) && gameObject.GetComponent<TankScript>().isPlayer2Input == true)
            {
                Cooldown = true;
                UIController.GetComponent<UIAbilitiesScript>().triggercooldown2P2 = true;
                timeBtwShots = cd;

                TeleportEnabled = true;
            
                elapsedTime = 0;

                AudioSource audio = TankCollider.GetComponent<AudioSource>();
                audio.clip = phase;
                audio.Play();
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
            CBar.currentCD = timeBtwShots;
        }
        if (timeBtwShots <= 0)
        {
            Cooldown = false;
        }
        elapsedTime += timeamountincrease * Time.deltaTime;
        
        if (elapsedTime >= 5)

        {

            TeleportOff();

        }

    
        if (TeleportEnabled == true)

        {

            TeleportOn();

        }

        else 

        {

            TeleportOff();

        }

    }


    private void TeleportOff()

    {

        Physics2D.IgnoreLayerCollision (8, 9, false);

        Physics2D.IgnoreLayerCollision (8, 10, false);

        TeleportEnabled= false;

        Render.color = new Color (Render.color.r, Render.color.g, Render.color.b, 1f);

    }

    private void TeleportOn()

    {

        Physics2D.IgnoreLayerCollision (8, 9, true);

        Physics2D.IgnoreLayerCollision (8, 10, true);

        Render.color = new Color (Render.color.r, Render.color.g, Render.color.b, .5f);

    }

}
