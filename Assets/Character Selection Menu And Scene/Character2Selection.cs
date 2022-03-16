using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character2Selection : MonoBehaviour
{
    
    public GameObject[] player2Objects;
    public int selected2Character = 0;

    private string selected2CharacterDataName = "Selected2Character";

    void Start()
    {

        HideAllCharacters();
        selected2Character = PlayerPrefs.GetInt(selected2CharacterDataName, 0);
    }


    private void HideAllCharacters()
    {
        foreach (GameObject g in player2Objects)
        {
            g.SetActive(false);
        }
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt(selected2CharacterDataName, selected2Character);
    }
}
