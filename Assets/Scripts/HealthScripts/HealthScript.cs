using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{ 
    private Scene scene;

    private GameObject gameManager;


    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        scene = SceneManager.GetActiveScene();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" & gameObject.tag == "Player1")
        {
            DontDestroyOnLoad(gameManager);
            SceneManager.LoadScene(scene.name);
            gameManager.GetComponent<gamemanagerscript>().player1hitCount += 1;
        }

        if (collision.gameObject.tag == "Bullet" & gameObject.tag == "Player2")
        {
            DontDestroyOnLoad(gameManager);
            SceneManager.LoadScene(scene.name);
            gameManager.GetComponent<gamemanagerscript>().player2hitCount += 1;
        }
    }
}
