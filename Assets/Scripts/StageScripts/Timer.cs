using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float roundTime = 120;
    public bool timerIsRunning = false;
    public Text timeText;
    public GameObject TheGameOver;
    public float theTime;
    public AudioClip SpecialMusic;
    public bool themePlaying;
    private void Start()
    {
        timerIsRunning = true;
        theTime = roundTime;
         
    }
    void Update()
    {
        if (GameObject.Find("One's Greatest High(Clone)") != null && themePlaying == false)
        {
            AudioSource audio = timeText.GetComponent<AudioSource>();
            audio.clip = SpecialMusic;
            audio.Play(); 
            themePlaying = true;
        }
        if (timerIsRunning)
        {
            if (theTime > 0)
            {
                theTime -= Time.deltaTime;
                DisplayTime(theTime);
            }
            else
            {
                Debug.Log("Time has run out!");
                theTime = 0;
                timerIsRunning = false;
            }

            if (Mathf.Round(theTime) == 2)
            {
                TheGameOver = GameObject.Find("One's Greatest High(Clone)");
                GameObject child1 = TheGameOver.transform.GetChild(0).gameObject;
                GameObject childofchild = child1.transform.GetChild(5).gameObject;
                GameOver scr = childofchild.GetComponent<GameOver>();
                scr.Serious = true;
                Debug.Log("burh");
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
