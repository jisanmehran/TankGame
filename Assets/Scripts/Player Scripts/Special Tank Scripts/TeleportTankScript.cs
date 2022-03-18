
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


    private void Update()

    {

        elapsedTime += timeamountincrease * Time.deltaTime;
        
        
        if (Input.GetKey(KeyCode.LeftAlt) | Input.GetKey(KeyCode.RightAlt) && gameObject.GetComponent<TankScript>().isPlayer2Input == false)

        {

            TeleportEnabled = true;
            
            elapsedTime = 0;

            AudioSource audio = TankCollider.GetComponent<AudioSource>();
            audio.clip = phase;
            audio.Play();
        }

        if (Input.GetKeyDown(KeyCode.S) && gameObject.GetComponent<TankScript>().isPlayer2Input == true)

        {

            TeleportEnabled = true;
            
            elapsedTime = 0;

            AudioSource audio = TankCollider.GetComponent<AudioSource>();
            audio.clip = phase;
            audio.Play();
        }


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

    }

    private void TeleportOn()

    {

        Physics2D.IgnoreLayerCollision (8, 9, true);

        Physics2D.IgnoreLayerCollision (8, 10, true);

    }

}
