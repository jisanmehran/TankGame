using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Choice : MonoBehaviour
{
    public Image ImageChoice;

    //public bool OneSelected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            RectTransform picture = ImageChoice.GetComponent<RectTransform>();
            if (picture.anchoredPosition.y != -24)
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y+40);
            }     
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            RectTransform picture = ImageChoice.GetComponent<RectTransform>();
            if (picture.anchoredPosition.y != -64)
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y-40);
            }    
        }
        if (Input.GetKeyDown("z"))
        {
            RectTransform picture = ImageChoice.GetComponent<RectTransform>();
            if (picture.anchoredPosition == new Vector2(0,-24))
            {
               SceneManager.LoadScene(sceneName:"Character Selection Menu");
            }
            else if (picture.anchoredPosition == new Vector2(0,-64))
            {
                //Application.Quit();
            }
        }   
    }
}
