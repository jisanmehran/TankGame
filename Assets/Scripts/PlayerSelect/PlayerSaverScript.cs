using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSaverScript : MonoBehaviour
{

    public GameObject CharacterSelectorScript;
    public GameObject Player2CharacterSelectorScript;

    private string WhichPlayer;

    public GameObject ErrorMessagePanel;
    public GameObject NotAvailableMessagePanel;
    public Text ReturntoScreenText;
    public Text ReturntoScreenforNotAvailText;
    public Text Playerdeterminererrortext;

    private float TimeElapsed;
    private float timeincrease = 1f;

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
        TimeElapsed += timeincrease * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (CharacterSelectorScript.GetComponent<CharacterSelectionMenu>().selectedCharacter == Player2CharacterSelectorScript.GetComponent<Character2Selection>().selected2Character)
            {
                ErrorMessagePanel.SetActive(true);
                TimeElapsed = 0;
            }

            if (CharacterSelectorScript.GetComponent<CharacterSelectionMenu>().selectedCharacter != Player2CharacterSelectorScript.GetComponent<Character2Selection>().selected2Character)
            {
                if (Player2CharacterSelectorScript.GetComponent<Character2Selection>().selected2Character <= 3)
                {
                    if (CharacterSelectorScript.GetComponent<CharacterSelectionMenu>().selectedCharacter <=3)
                    {
                        SceneManager.LoadScene("MapChooseScreen");                
                    }
                }
            }

            if (CharacterSelectorScript.GetComponent<CharacterSelectionMenu>().selectedCharacter > 3)
            {
                NotAvailableMessagePanel.SetActive(true);
                TimeElapsed = 0;
                WhichPlayer = ("Player 1");
            }

            if (Player2CharacterSelectorScript.GetComponent<Character2Selection>().selected2Character > 3)
            {
                NotAvailableMessagePanel.SetActive(true);
                TimeElapsed = 0;
                WhichPlayer = ("Player 2");
            }
        }

        if (TimeElapsed >= 4)
        {
            TurnOffErrorMessage();
        }

        ReturntoScreenText.text = ("returning to screen in " + Mathf.RoundToInt(TimeElapsed).ToString() +" seconds");
        ReturntoScreenforNotAvailText.text = ("returning to screen in " + Mathf.RoundToInt(TimeElapsed).ToString() +" seconds");
        Playerdeterminererrortext.text = (WhichPlayer + " Must Select a Tank");
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player1Select")
        {
            CharacterSelectorScript.GetComponent<CharacterSelectionMenu>().selectedCharacter = selectionOnGrid;
            CharacterSelectorScript.GetComponent<CharacterSelectionMenu>().StartGame();
        }

        if (other.gameObject.tag == "Player2Select")
        {
            Player2CharacterSelectorScript.GetComponent<Character2Selection>().selected2Character = selectionOnGrid;
            Player2CharacterSelectorScript.GetComponent<Character2Selection>().StartGame();
        }

    }

    void TurnOffErrorMessage ()
    {
        ErrorMessagePanel.SetActive(false);
        NotAvailableMessagePanel.SetActive(false);
    }
}
