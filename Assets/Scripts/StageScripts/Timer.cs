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
    private void Start()
    {
        timerIsRunning = true;
        theTime = roundTime;
    }
    void Update()
    {
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

            if (theTime == roundTime/2)
            {
                GameOver scr = TheGameOver.GetComponent<GameOver>();
                scr.Serious = true;
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
