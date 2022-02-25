using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSaverScript : MonoBehaviour
{

    public GameObject CharacterSelectorScript;
    public GameObject Player2CharacterSelectorScript;

    public int selectionOnGrid;
    // Start is called before the first frame update
    void Start()
    {
        CharacterSelectorScript = GameObject.Find("Script-CharacterSelection");
        Player2CharacterSelectorScript = GameObject.Find("Player2CharacterSelection");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Map1");
        }
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player1Select")
        {
            CharacterSelectorScript.GetComponent<CharacterSelectionMenu>().selectedCharacter = selectionOnGrid;
            CharacterSelectorScript.GetComponent<CharacterSelectionMenu>().StartGame();
            Debug.Log("Player 1 Tank is changed to element " + selectionOnGrid);
        }

        if (other.gameObject.tag == "Player2Select")
        {
            Player2CharacterSelectorScript.GetComponent<Character2Selection>().selected2Character = selectionOnGrid;
            Player2CharacterSelectorScript.GetComponent<Character2Selection>().StartGame();
            Debug.Log("Player 2 Tank is changed to element " + selectionOnGrid);
        }

    }
}
