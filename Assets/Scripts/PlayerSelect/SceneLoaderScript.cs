using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderScript : MonoBehaviour
{
    public string LevelText;

    public string LevelOption;

    public Text MapSelectionScreen;

    public Image POneSelect;

    public GameObject MapSelectorContainer;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.W))
        {
            RectTransform picture = POneSelect.GetComponent<RectTransform>();
            if (picture.anchoredPosition.y != 0)
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y+75);
            }     
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            RectTransform picture = POneSelect.GetComponent<RectTransform>();
            if (picture.anchoredPosition.x != -150)
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x-75, picture.anchoredPosition.y);
            }          
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            RectTransform picture = POneSelect.GetComponent<RectTransform>();
            if (picture.anchoredPosition.y != -150)
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y-75);
            }
        
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            RectTransform picture = POneSelect.GetComponent<RectTransform>();
            if (picture.anchoredPosition.x != 0)
            {
                picture.anchoredPosition = new Vector2(picture.anchoredPosition.x+75, picture.anchoredPosition.y);
            }         
        }
    
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "mapselector")
        {
            MapSelectionScreen.text = LevelText;
            MapSelectorContainer.GetComponent<MapOptionSelect>().Level = LevelOption;
        }
    }
}