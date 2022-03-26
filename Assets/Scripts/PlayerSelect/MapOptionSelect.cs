using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapOptionSelect : MonoBehaviour
{
    
    public string Level;
    private GameObject levelloader;

    void Start()
    {
        levelloader = GameObject.Find("LevelLoader");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            levelloader.GetComponent<LevelLoader>().loadingScreen.SetActive(true);
            levelloader.GetComponent<LevelLoader>().LoadLevel(Level);
        }
    }
}
