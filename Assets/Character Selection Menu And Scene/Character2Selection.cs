using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character2Selection : MonoBehaviour
{
    
    public GameObject[] player2Objects;
    public int selected2Character = 0;

    public string gameScene;

    private string selected2CharacterDataName = "Selected2Character";

    void Start()
    {

        HideAllCharacters();

        selected2Character = PlayerPrefs.GetInt(selected2CharacterDataName, 0);

        player2Objects[selected2Character].SetActive(true);
    }


    private void HideAllCharacters()
    {
        foreach (GameObject g in player2Objects)
        {
            g.SetActive(false);
        }
    }

    public void NextCharacter()
    {
        player2Objects[selected2Character].SetActive(false);
        selected2Character++;
        if (selected2Character >= player2Objects.Length)
        {
            selected2Character = 0;
        }
        player2Objects[selected2Character].SetActive(true);
    }

    public void PreviousCharacter()
    {
        player2Objects[selected2Character].SetActive(false);
        selected2Character--;
        if (selected2Character < 0)
        {
            selected2Character = player2Objects.Length-1;
        }
        player2Objects[selected2Character].SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt(selected2CharacterDataName, selected2Character);
        SceneManager.LoadScene("Map1");
    }
}
