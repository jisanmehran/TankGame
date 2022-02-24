using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject button1;

    void Start()
    {

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName:"Character Selection Menu");
    }
}
