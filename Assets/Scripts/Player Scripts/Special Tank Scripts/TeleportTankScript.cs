
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

    private void Update()

    {

        elapsedTime += timeamountincrease * Time.deltaTime;

        //Detect if the player pressed e 

        if (Input.GetKeyDown(KeyCode.E))

        {

            TeleportEnabled = true;
            
            elapsedTime = 0;

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

        TeleportEnabled= false;

    }

    private void TeleportOn()

    {

        Physics2D.IgnoreLayerCollision (8, 9, true);

    }

}
