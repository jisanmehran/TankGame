using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GilgameshTank : MonoBehaviour
{


    public string keyMoveForward;
    public string keyMoveReverse;
    public string keyRotateRight;
    public string keyRotateLeft;

    bool moveForward = false;
    bool moveReverse = false;
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

    void Update ()
    {

        rotateLeft = ( Input.GetKeyDown(keyRotateLeft ) ) ? true : rotateLeft;

        rotateLeft = ( Input.GetKeyUp(keyRotateLeft ) ) ? false : rotateLeft;

        if ( rotateLeft )

        {

            rotateSpeedLeft = ( rotateSpeedLeft < rotateSpeedMax ) ? rotateSpeedLeft + rotateAcceleration : rotateSpeedMax; } else { rotateSpeedLeft = ( rotateSpeedLeft > 0 ) ? rotateSpeedLeft - rotateDeceleration : 0;
        
        }

        transform.Rotate(0f, 0f, rotateSpeedLeft * Time.deltaTime);

        rotateRight = ( Input.GetKeyDown(keyRotateRight ) ) ? true : rotateRight;

        rotateRight = ( Input.GetKeyUp(keyRotateRight ) ) ? false : rotateRight;

        if ( rotateRight )

        {
            
            rotateSpeedRight = ( rotateSpeedRight < rotateSpeedMax ) ? rotateSpeedRight + rotateAcceleration : rotateSpeedMax; } else { rotateSpeedRight = ( rotateSpeedRight > 0 ) ? rotateSpeedRight - rotateDeceleration : 0;
        
        }

        transform.Rotate( 0f, 0f, rotateSpeedRight * Time.deltaTime * -1f );

        moveForward = ( Input.GetKeyDown(keyMoveForward ) ) ? true : moveForward;
        
        moveForward = ( Input.GetKeyUp(keyMoveForward ) ) ? false : moveForward;
        
        if ( moveForward )

        {
            
            moveSpeed = ( moveSpeed < moveSpeedMax ) ? moveSpeed + moveAcceleration : moveSpeedMax; } else { moveSpeed = ( moveSpeed > 0 ) ? moveSpeed - moveDeceleration : 0;
        
        }

        transform.Translate( 0f, moveSpeed * Time.deltaTime, 0f );

        moveReverse = ( Input.GetKeyDown ( keyMoveReverse ) ) ? true : moveReverse;

        moveReverse = ( Input.GetKeyUp ( keyMoveReverse ) ) ? false : moveReverse;

        if ( moveReverse )

        {

            moveSpeedReverse = ( moveSpeedReverse < moveSpeedMax) ? moveSpeedReverse + moveAcceleration : moveSpeedMax; } else { moveSpeedReverse = ( moveSpeedReverse > 0 ) ? moveSpeedReverse - moveDeceleration : 0;
        
        }

        transform.Translate( 0f, moveSpeedReverse * Time.deltaTime * -1f, 0f );
    }
}
