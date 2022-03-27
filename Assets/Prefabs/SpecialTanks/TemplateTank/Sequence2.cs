using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence2 : MonoBehaviour
{
    private string SequenceTwo;
    private string InputSequence2;
    private bool KeyPressed;
    private float timetopress;
    private float cd;
    public GameObject Player2CharacterSelectorScript;
    public bool SecretActive;

    // Start is called before the first frame update
    void Start()
    {
        //Player2CharacterSelectorScript = GameObject.Find("Player2CharacterSelection");
        SequenceTwo = "RDDFGGQA";
        KeyPressed = false;
        cd = 7;
        timetopress = cd;
        InputSequence2 = "filler";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (KeyPressed == false)
            {
                KeyPressed = true;
                InputSequence2 = "R";
            }
        }
        if (KeyPressed == true)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                InputSequence2 += "D";
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                InputSequence2 += "S";
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                InputSequence2 += "F";
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                InputSequence2 += "G";
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                InputSequence2 += "Q";
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                InputSequence2 += "A";
            }
        }
        

        if (InputSequence2.Length == SequenceTwo.Length)
        {
            if (InputSequence2 == SequenceTwo)
            {
                Player2CharacterSelectorScript.GetComponent<Character2Selection>().selected2Character = 4;
                Player2CharacterSelectorScript.GetComponent<Character2Selection>().StartGame();
                Debug.Log("secret activated");
                SecretActive = true;
            }
            else
            {
                InputSequence2 = "";
                //Debug.Log("Failed2");
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
            //Debug.Log("Reset2");
            InputSequence2 = "";
        }
        
        //print(InputSequence2);
    }
}
