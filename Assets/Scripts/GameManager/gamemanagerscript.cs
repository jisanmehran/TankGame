using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanagerscript : MonoBehaviour
{
    public int player1hitCount;
    public int player2hitCount;

    // Update is called once per frame
    void Update()
    {
        if (player1hitCount == 3)
        {
            Invoke("loadPlayAgainScreen", 2f);
            destroyGameManager();
        }

        else if (player2hitCount == 3)
        {
            Invoke("loadPlayAgainScreen", 2f);
            destroyGameManager();
        }
        
    }

    void destroyGameManager()
    {
        Destroy(gameObject);
    }

    void loadPlayAgainScreen()
    {
        SceneManager.LoadScene("PlayAgain");
    }
}
