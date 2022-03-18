using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Choice : MonoBehaviour
{
    public int QuitorReplay;
    public Image ImageChoice;
    public AudioClip Selection;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("up"))
        {
            RectTransform picture = ImageChoice.GetComponent<RectTransform>();
            if (picture.anchoredPosition.y != -24)
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y+40);
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = Selection;
                audio.Play();
            }

            QuitorReplay = 2;     
        }

        else if (Input.GetKeyDown("r"))
        {
            RectTransform picture = ImageChoice.GetComponent<RectTransform>();
            if (picture.anchoredPosition.y != -24)
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y+40);
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = Selection;
                audio.Play();
            }

            QuitorReplay = 2;  
        }

        else if (Input.GetKeyDown("down"))
        {
            RectTransform picture = ImageChoice.GetComponent<RectTransform>();
            if (picture.anchoredPosition.y != -64)
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y-40);
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = Selection;
                audio.Play();
            }

            QuitorReplay = 1;    
        }

        else if (Input.GetKeyDown("f"))
        {
            RectTransform picture = ImageChoice.GetComponent<RectTransform>();
            if (picture.anchoredPosition.y != -64)
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y-40);
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = Selection;
                audio.Play();
            }

            QuitorReplay = 1; 
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            
            if (QuitorReplay == 1)
            {
                Application.Quit();
            }

            if (QuitorReplay == 2)
            {
                SceneManager.LoadScene(sceneName:"ChooseScreen"); 
            }
        }
    }
}