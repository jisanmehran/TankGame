using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierMovement : MonoBehaviour
{
    public Transform Barrier;
    private bool Direction;
    public float speed;
    //false is down, true is up
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Direction == true)
        {
            Barrier.position = new Vector2(Barrier.position.x, Barrier.position.y + speed);
        }  
        else if (Direction == false)
        {
            Barrier.position = new Vector2(Barrier.position.x, Barrier.position.y - speed);
        }

        if (Barrier.position.y >= 4)
        {
            Direction = false;
        }
        else if (Barrier.position.y <= -4)
        {
            Direction = true;
        }
        
    }
}
