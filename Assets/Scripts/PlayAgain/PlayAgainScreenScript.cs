using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainScreenScript : MonoBehaviour
{
    public int QuitorReplay;


    void Update()
    {
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
