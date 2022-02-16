
using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class TankScript : MonoBehaviour

{

//Variables

    //public Track trackLeft;
    //public Track trackRight;

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


//Functions




    void Update ( )

    {
        
        if (isPlayer2Input == true)
        {

            rotateLeft = ( Input.GetKeyDown("a") ) ? true : rotateLeft;

            rotateLeft = ( Input.GetKeyUp("a") ) ? false : rotateLeft;

            if ( rotateLeft )

            {

                rotateSpeedLeft = ( rotateSpeedLeft < rotateSpeedMax ) ? rotateSpeedLeft + rotateAcceleration : rotateSpeedMax; } else { rotateSpeedLeft = ( rotateSpeedLeft > 0 ) ? rotateSpeedLeft - rotateDeceleration : 0;
            
            }

            transform.Rotate(0f, 0f, rotateSpeedLeft * Time.deltaTime);

            rotateRight = ( Input.GetKeyDown("d") ) ? true : rotateRight;

            rotateRight = ( Input.GetKeyUp("d") ) ? false : rotateRight;

            if ( rotateRight )

            {
                
                rotateSpeedRight = ( rotateSpeedRight < rotateSpeedMax ) ? rotateSpeedRight + rotateAcceleration : rotateSpeedMax; } else { rotateSpeedRight = ( rotateSpeedRight > 0 ) ? rotateSpeedRight - rotateDeceleration : 0;
            
            }

            transform.Rotate( 0f, 0f, rotateSpeedRight * Time.deltaTime * -1f );

            moveForward = ( Input.GetKeyDown("w") ) ? true : moveForward;
            
            moveForward = ( Input.GetKeyUp("w") ) ? false : moveForward;
            
            if ( moveForward )

            {
                
                moveSpeed = ( moveSpeed < moveSpeedMax ) ? moveSpeed + moveAcceleration : moveSpeedMax; } else { moveSpeed = ( moveSpeed > 0 ) ? moveSpeed - moveDeceleration : 0;
            
            }

            transform.Translate( 0f, moveSpeed * Time.deltaTime, 0f );

            moveReverse = ( Input.GetKeyDown ( "s" ) ) ? true : moveReverse;

            moveReverse = ( Input.GetKeyUp ( "s" ) ) ? false : moveReverse;

            if ( moveReverse )

            {

                moveSpeedReverse = ( moveSpeedReverse < moveSpeedMax) ? moveSpeedReverse + moveAcceleration : moveSpeedMax; } else { moveSpeedReverse = ( moveSpeedReverse > 0 ) ? moveSpeedReverse - moveDeceleration : 0;
            
            }

            transform.Translate( 0f, moveSpeedReverse * Time.deltaTime * -1f, 0f );
        }

        if (isPlayer2Input == false)
        {
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
        // if (moveForward | moveReverse | rotateRight | rotateLeft)
        // {
        //     trackStart();
        // }
        // else
        // {
        //     trackStop();
        // }

    }
    // void trackStart()
    // {
    //     trackLeft.animator.SetBool("isMoving", true);
    //     trackRight.animator.SetBool("isMoving", true);
    // }

    // void trackStop()
    // {
    //     trackLeft.animator.SetBool("isMoving", false);
    //     trackRight.animator.SetBool("isMoving", false);
    // }

}
