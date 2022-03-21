using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIGraphicsScript : MonoBehaviour
{
    public AIPath aiPath;

    private Path path;

    private int currentWaypoint = 0;

    // Update is called once per frame
    //Create one script for to Handle all the ai using brackeys tutorial and then have the script update to each map dynamically using the InvokeRepeatingMethod
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
