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

    // Start is called before the first frame update
    void Start()
    {   
        selectedCharacter = PlayerPrefs.GetInt(selectedCharacterDataName,0);
        characters[selectedCharacter].SetActive(true);
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

    // // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         ReturnToMainMenu();
    //     }
    // }

    // public void ReturnToMainMenu()
    // {
    //     SceneManager.LoadScene(menuScene);

    // }

}