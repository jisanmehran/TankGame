
using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

public class TankScript : MonoBehaviour

{

//Variables

    //public Track trackLeft;
    //public Track trackRight;

    public float holdTime = 3.0f;
 
    private float startTime = 0f;
    private float timer = 0f;
 
    private bool held = false;

    public string keyMoveForward;
    public string keyMoveReverse;
    public string keyRotateRight;
    public string keyRotateLeft;

    bool moveForward = false;
    bool moveReverse = false;

    public bool isPlayer2Input;
    public float moveSpeed = 0f;
    public float moveSpeedReverse = 0f;
    public float moveAcceleration = 0.1f;
    public float moveDeceleration = 0.20f;
    public float moveSpeedMax = 2.5f;

    bool rotateRight = false;
    bool rotateLeft = false;
    public float rotateSpeedRight = 0f;
    public float rotateSpeedLeft = 0f;
    public float rotateAcceleration = 4f;
    public float rotateDeceleration = 10f;
    public float rotateSpeedMax = 130f;

    //Image Variables

    public Sprite broken1;
    public Sprite broken2;
    private float angle;

    public float turnSpeed;

    Vector2 input;
    Quaternion targetRotation;
    Transform cam;


//Functions

    private void Start()
    {
        cam = Camera.main.transform;
    }
    private void HandleMameInputs()
        {

            ///////////////////////////////////////////
            //  Default Keymap	
            ///////////////////////////////////////////
            /* Main Keys	
            5,6,7,8	   Insert coin	
            1,2,3,4	   Players 1 - 4 start buttons	
            
            Arrow Keys	Controller (Player 1)	
            
            Left Ctrl	Fire 1 (Player 1)	
            Left Alt	Fire 2 (Player 1)	
            Space	    Fire 3 (Player 1)	
            Left Shift	Fire 4 (Player 1)	
            Z	        Fire 5 (Player 1)	
            X           Fire 6(Player 1)	
            
            R,F,G,D	Controller (Player 2)	
            A         Fire 1 (Player 2)	
            S         Fire 2 (Player 2)	
            Q         Fire 3 (Player 2)	
            W         Fire 4 (Player 2)	
            E         Fire 5 (Player 2)	Not set by default
            T         Fire 6 (Player 2)	Not Set By Default	
            
            Playchoice 10 Additional Keys	
            5         Adds Time	
            0         Select Game	
            1         Toggles 1 or 2 Player Mode	
            2         Start Game
            */
    }
    void Update ( )

    {
        HandleGameExit();
        HandleMameInputs();
        EscapeButtonHeld();
        
        if (isPlayer2Input == false)
        {
            //input.x = Input.GetAxisRaw("Horizontal");
            //input.y = Input.GetAxisRaw("Vertical");

            rotateLeft = ( Input.GetKeyDown("left") ) ? true : rotateLeft;

            rotateLeft = ( Input.GetKeyUp("left") ) ? false : rotateLeft;

            if ( rotateLeft )

            {

                rotateSpeedLeft = ( rotateSpeedLeft < rotateSpeedMax ) ? rotateSpeedLeft + rotateAcceleration : rotateSpeedMax; } else { rotateSpeedLeft = ( rotateSpeedLeft > 0 ) ? rotateSpeedLeft - rotateDeceleration : 0;
            
            }

            transform.Rotate(0f, 0f, rotateSpeedLeft * Time.deltaTime);

            rotateRight = ( Input.GetKeyDown("right") ) ? true : rotateRight;

            rotateRight = ( Input.GetKeyUp("right") ) ? false : rotateRight;

            if ( rotateRight )

            {
                
                rotateSpeedRight = ( rotateSpeedRight < rotateSpeedMax ) ? rotateSpeedRight + rotateAcceleration : rotateSpeedMax; } else { rotateSpeedRight = ( rotateSpeedRight > 0 ) ? rotateSpeedRight - rotateDeceleration : 0;
            
            }

            transform.Rotate( 0f, 0f, rotateSpeedRight * Time.deltaTime * -1f );

            moveForward = ( Input.GetKeyDown("up") ) ? true : moveForward;
            
            moveForward = ( Input.GetKeyUp("up") ) ? false : moveForward;
            
            if ( moveForward )

            {
                
                moveSpeed = ( moveSpeed < moveSpeedMax ) ? moveSpeed + moveAcceleration : moveSpeedMax; } else { moveSpeed = ( moveSpeed > 0 ) ? moveSpeed - moveDeceleration : 0;
            
            }

            transform.Translate( 0f, moveSpeed * Time.deltaTime, 0f );

            moveReverse = ( Input.GetKeyDown ( "down" ) ) ? true : moveReverse;

            moveReverse = ( Input.GetKeyUp ( "down" ) ) ? false : moveReverse;

            if ( moveReverse )

            {

                moveSpeedReverse = ( moveSpeedReverse < moveSpeedMax) ? moveSpeedReverse + moveAcceleration : moveSpeedMax; } else { moveSpeedReverse = ( moveSpeedReverse > 0 ) ? moveSpeedReverse - moveDeceleration : 0;
            
            }

            transform.Translate( 0f, moveSpeedReverse * Time.deltaTime * -1f, 0f );
        }

        if (isPlayer2Input == true)
        {
            rotateLeft = ( Input.GetKeyDown("d") ) ? true : rotateLeft;

            rotateLeft = ( Input.GetKeyUp("d") ) ? false : rotateLeft;

            if ( rotateLeft )

            {

                rotateSpeedLeft = ( rotateSpeedLeft < rotateSpeedMax ) ? rotateSpeedLeft + rotateAcceleration : rotateSpeedMax; } else { rotateSpeedLeft = ( rotateSpeedLeft > 0 ) ? rotateSpeedLeft - rotateDeceleration : 0;
            
            }

            transform.Rotate(0f, 0f, rotateSpeedLeft * Time.deltaTime);

            rotateRight = ( Input.GetKeyDown("g") ) ? true : rotateRight;

            rotateRight = ( Input.GetKeyUp("g") ) ? false : rotateRight;

            if ( rotateRight )

            {
                
                rotateSpeedRight = ( rotateSpeedRight < rotateSpeedMax ) ? rotateSpeedRight + rotateAcceleration : rotateSpeedMax; } else { rotateSpeedRight = ( rotateSpeedRight > 0 ) ? rotateSpeedRight - rotateDeceleration : 0;
            
            }

            transform.Rotate( 0f, 0f, rotateSpeedRight * Time.deltaTime * -1f );

            moveForward = ( Input.GetKeyDown("r") ) ? true : moveForward;
            
            moveForward = ( Input.GetKeyUp("r") ) ? false : moveForward;
            
            if ( moveForward )

            {
                
                moveSpeed = ( moveSpeed < moveSpeedMax ) ? moveSpeed + moveAcceleration : moveSpeedMax; } else { moveSpeed = ( moveSpeed > 0 ) ? moveSpeed - moveDeceleration : 0;
            
            }

            transform.Translate( 0f, moveSpeed * Time.deltaTime, 0f );

            moveReverse = ( Input.GetKeyDown ( "f" ) ) ? true : moveReverse;

            moveReverse = ( Input.GetKeyUp ( "f" ) ) ? false : moveReverse;

            if ( moveReverse )

            {

                moveSpeedReverse = ( moveSpeedReverse < moveSpeedMax) ? moveSpeedReverse + moveAcceleration : moveSpeedMax; } else { moveSpeedReverse = ( moveSpeedReverse > 0 ) ? moveSpeedReverse - moveDeceleration : 0;
            
            }

            transform.Translate( 0f, moveSpeedReverse * Time.deltaTime * -1f, 0f );
        }
    }

    // private void CalculateDirection()
    // {
    //     angle = Mathf.Atan2(input.x, input.y);
    //     angle = Mathf.Rad2Deg * angle;
    //     angle += cam.eulerAngles.y; 
    // }

    // private void rotate()
    // {
    //     targetRotation = Quaternion.Euler(0, angle, 0);
    //     transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    // }

    // private void move()
    // {
    //     transform.position += transform.forward * moveSpeed * Time.deltaTime;
    // }
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
    }

    
    void EscapeButtonHeld()
    {
        //Debug.Log("held for " + holdTime + " seconds");
        //Application.Quit();
    }
}
