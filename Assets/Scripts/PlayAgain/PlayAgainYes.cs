using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayAgainYes : MonoBehaviour
{
    public GameObject button1;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(sceneName:"Character Selection Menu");
    }
}
