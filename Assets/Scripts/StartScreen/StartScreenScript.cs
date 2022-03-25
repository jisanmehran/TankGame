using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenScript : MonoBehaviour
{
    private bool StartGame;
    public Image ImageChoice;
    public AudioClip Selection;

    void Start ()
    {
        StartGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            StartGame = true;     
            RectTransform picture = ImageChoice.GetComponent<RectTransform>();
            if (picture.anchoredPosition.y != -24)
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y+40);
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = Selection;
                audio.Play();
            }
        }

        else if (Input.GetKeyDown("r"))
        {
            StartGame = true;  
            RectTransform picture = ImageChoice.GetComponent<RectTransform>();
            if (picture.anchoredPosition.y != -24)
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y+40);
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = Selection;
                audio.Play();
            }
        }

        else if (Input.GetKeyDown("down"))
        {
            StartGame = false;    
            RectTransform picture = ImageChoice.GetComponent<RectTransform>();
            if (picture.anchoredPosition.y != -104)
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y-40);
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = Selection;
                audio.Play();
            }
        }

        else if (Input.GetKeyDown("f"))
        {
            StartGame = false; 
            RectTransform picture = ImageChoice.GetComponent<RectTransform>();
            if (picture.anchoredPosition.y != -104)
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y-40);
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = Selection;
                audio.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RectTransform picture = ImageChoice.GetComponent<RectTransform>();
            if (picture.anchoredPosition.y == -64)
            {
                Application.Quit();
            }

            if (picture.anchoredPosition.y == -24)
            {
                SceneManager.LoadScene("ChooseScreen"); 
            }

            if (picture.anchoredPosition.y == -104)
            {
                SceneManager.LoadScene("RuleScreen"); 
            }
        }
    }
}
