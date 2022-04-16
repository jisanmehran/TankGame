using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public GameObject AccuracyTracker;
    private void Start()
    {
        AccuracyTracker = GameObject.Find("AccuracyTracker");
        timerIsRunning = true;
        theTime = roundTime;
        themePlaying = false;
    }
    void Update()
    {
        if (GameObject.Find("One's Greatest High(Clone)") != null && themePlaying == false)
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
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
                DontDestroyOnLoad(AccuracyTracker);
                SceneManager.LoadScene("PlayAgainBoth");
                theTime = 0;
                timerIsRunning = false;
            }

            if (Mathf.Round(theTime) == roundTime/2)
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
