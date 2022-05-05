using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    public GameObject[] characters;
    public Transform playerStartPosition;
    private string selectedCharacterDataName = "SelectedCharacter";
    public int selectedCharacter;
    public GameObject playerObject;

    public GameObject Aitank;

    public bool TargetPlayer1;

    private GameObject TanktoSpawn;

    public GameObject TPCDP1Icon;
    public GameObject TPCDP2Icon;
    public GameObject AICDP1Icon;
    public GameObject AICDP2Icon;

    public GameObject SNTankCDIcon1;
    public GameObject SNTankCDIcon2;

    public GameObject BMTankCDIcon1;
    public GameObject BMTankCDIcon2;

    public GameObject SHTankCDIcon1;
    public GameObject SHTankCDIcon2;

    // Start is called before the first frame update
    void Start()
    {   

        selectedCharacter = PlayerPrefs.GetInt(selectedCharacterDataName,0);
        characters[selectedCharacter].SetActive(true);

        if (selectedCharacter == 0)
        {
            TPCDP1Icon.SetActive(true);
        }

        else if (selectedCharacter == 2)
        {
            AICDP1Icon.SetActive(true);
        }

        else if (selectedCharacter == 5)
        {
            BMTankCDIcon1.SetActive(true);
        }

        else if (selectedCharacter == 6)
        {
            SNTankCDIcon1.SetActive(true);
        }

        else if (selectedCharacter == 9)
        {
            SHTankCDIcon1.SetActive(true);
        }

        playerObject = Instantiate(characters[selectedCharacter], playerStartPosition.position, characters[selectedCharacter].transform.rotation);
        playerObject.GetComponent<TankScript>().isPlayer2Input = false;
        playerObject.tag = "Player1";

        if (selectedCharacter == 2)
        {
            TargetPlayer1 = false;
            Aitank.GetComponent<AIDestinationSetter>().TargetPlayer1 = false; 

        }

        if(selectedCharacter != 2)
        {
            TargetPlayer1 = true;
            Aitank.GetComponent<AIDestinationSetter>().TargetPlayer1 = true; 

        }

        
    }

}