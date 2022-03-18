using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject button1;
    public AudioClip startSound;
    public AudioSource theAudio;
    public bool clicked;
    void Start()
    {
        clicked = false;
        theAudio = gameObject.GetComponent<AudioSource>();
    }
    public void PlayGame()
    {  
        GetComponent<AudioSource>().clip = startSound;
        GetComponent<AudioSource>().Play();
        clicked = true;
    }

    void Update()
    {
        if (theAudio.isPlaying == false && clicked == true)
        {
            SceneManager.LoadScene(sceneName:"ChooseScreen");
        }
    }
}
