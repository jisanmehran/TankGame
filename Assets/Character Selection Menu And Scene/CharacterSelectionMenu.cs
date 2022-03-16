using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionMenu : MonoBehaviour
{
    
    public GameObject[] playerObjects;
    public int selectedCharacter = 0;

    private string selectedCharacterDataName = "SelectedCharacter";

    void Start()
    {

        HideAllCharacters();
        selectedCharacter = PlayerPrefs.GetInt(selectedCharacterDataName, 0);
        selectedCharacter = 0;
    }


    private void HideAllCharacters()
    {
        foreach (GameObject g in playerObjects)
        {
            g.SetActive(false);
        }
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt(selectedCharacterDataName, selectedCharacter);
    }

}