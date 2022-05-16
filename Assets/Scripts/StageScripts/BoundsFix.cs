using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsFix : MonoBehaviour
{
    public GameObject Tankspawn1;
    public GameObject Tankspawn2;
    public GameObject GameControl;
    public GameObject GameControl2;
    // Start is called before the first frame update
    void Start()
    {
        Tankspawn1 = GameObject.Find("TankSpawn1");
        Tankspawn2 = GameObject.Find("TankSpawn2");
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1" & GameControl.GetComponent<GameControl>().selectedCharacter == 7)
        {
            other.gameObject.transform.position = Tankspawn1.transform.position;
        }
        else if(other.gameObject.tag == "Player2" & GameControl2.GetComponent<Game2Control>().selected2Character == 7)
        {
            other.gameObject.transform.position = Tankspawn2.transform.position;
        }
    }
}
