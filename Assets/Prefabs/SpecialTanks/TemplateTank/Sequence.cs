using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : MonoBehaviour
{
    private string Sequence1;
    private string InputSequence1;
    private bool KeyPressed;
    private float timetopress;
    private float cd;
    public GameObject CharacterSelectorScript;
    public bool SecretActive;

    // Start is called before the first frame update
    void Start()
    {
        //CharacterSelectorScript = GameObject.Find("Script-CharacterSelection");
        Sequence1 = "upleftleftdownrightrightFire3Fire1";
        KeyPressed = false;
        cd = 7;
        timetopress = cd;
        InputSequence1 = "filler";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            if (KeyPressed == false)
            {
                KeyPressed = true;
                InputSequence1 = "up";
            }
        }
        if (KeyPressed == true)
        {
            if (Input.GetKeyDown("left"))
            {
                InputSequence1 += "left";
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                InputSequence1 += "Fire2";
            }
            else if (Input.GetKeyDown("down"))
            {
                InputSequence1 += "down";
            }
            else if (Input.GetKeyDown("right"))
            {
                InputSequence1 += "right";
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                InputSequence1 += "Fire3";
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                InputSequence1 += "Fire1";
            }
        }
        

        if (InputSequence1.Length == Sequence1.Length)
        {
            if (InputSequence1 == Sequence1)
            {
                CharacterSelectorScript.GetComponent<CharacterSelectionMenu>().selectedCharacter = 4;
                CharacterSelectorScript.GetComponent<CharacterSelectionMenu>().StartGame();
                Debug.Log("secret activated");
                SecretActive = true;
            }
            else
            {
                InputSequence1 = "";
                //Debug.Log("Failed");
            }
        }

        if (KeyPressed == true)
        {
            timetopress -= Time.deltaTime;
        }

        if (timetopress <= 0)
        {
            KeyPressed = false;
            timetopress = cd;
            //Debug.Log("Reset");
            InputSequence1 = "";
        }
        //print(InputSequence1);

        
    }
}
