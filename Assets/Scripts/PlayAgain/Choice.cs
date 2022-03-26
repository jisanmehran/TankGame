using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Choice : MonoBehaviour
{
    private bool Replay;
    public Image ImageChoice;
    public GameObject levelloader;
    public AudioClip Selection;

    void Start ()
    {
        Replay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            Replay = true;     
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
            Replay = true;  
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
            Replay = false;    
            RectTransform picture = ImageChoice.GetComponent<RectTransform>();
            if (picture.anchoredPosition.y != -64)
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y-40);
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = Selection;
                audio.Play();
            }
        }

        else if (Input.GetKeyDown("f"))
        {
            Replay = false; 
            RectTransform picture = ImageChoice.GetComponent<RectTransform>();
            if (picture.anchoredPosition.y != -64)
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y-40);
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = Selection;
                audio.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            if (Replay == false)
            {
                Application.Quit();
            }

            if (Replay == true)
            {
                levelloader.GetComponent<LevelLoader>().LoadLevel("ChooseScreen"); 
            }
        }
    }
}