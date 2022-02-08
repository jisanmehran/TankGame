using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerSelect : MonoBehaviour
{
    public Image POneSelect;
    public Image PTwoSelect;
    public bool TankChosen1;
    public bool TankChosen2;
    public Image PlayerOne;
    public Image PlayerTwo;
    public Image Image1;
    public Image Image2;
    public Image Image3;
    public Image Image4;
    public Image Image5;
    public Image Image6;
    public Image Image7;
    public Image Image8;
    public Image Image9;

    //public bool OneSelected;
    // Start is called before the first frame update
    void Start()
    {
        TankChosen1 = false;
        TankChosen2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TankChosen1 == false) 
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
        if (TankChosen2 == false) 
        {
            if(Input.GetKeyDown("up"))
            {
                RectTransform picture = PTwoSelect.GetComponent<RectTransform>();
                if (picture.anchoredPosition.y != 0)
                {
                    picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y+75);
                }
            }
            else if(Input.GetKeyDown("left"))
            {
                RectTransform picture = PTwoSelect.GetComponent<RectTransform>();
                if (picture.anchoredPosition.x != -150)
                {
                    picture.anchoredPosition = new Vector2(picture.anchoredPosition.x-75, picture.anchoredPosition.y);
                }
            }
            else if (Input.GetKeyDown("down"))
            {
                RectTransform picture = PTwoSelect.GetComponent<RectTransform>();
                if (picture.anchoredPosition.y != -150)
                {
                    picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y-75);
                }
            }
            else if (Input.GetKeyDown("right"))
            {
                RectTransform picture = PTwoSelect.GetComponent<RectTransform>();
                if (picture.anchoredPosition.x != 0)
                {
                    picture.anchoredPosition = new Vector2(picture.anchoredPosition.x+75, picture.anchoredPosition.y);
                } 
            }
        } 
        if (Input.GetKeyDown("z"))
        {
            TankChosen1 = true;
            RectTransform picture = POneSelect.GetComponent<RectTransform>();
            if (picture.anchoredPosition == new Vector2(0,0))
            {
                PlayerOne.color = Image3.color;
            }
            else if (picture.anchoredPosition == new Vector2(0,-75))
            {
                PlayerOne.color = Image6.color;
            }
            else if (picture.anchoredPosition == new Vector2(0,-150))
            {
                PlayerOne.color = Image9.color;
            }
            else if (picture.anchoredPosition == new Vector2(-75,0))
            {
                PlayerOne.color = Image2.color;
            }
            else if (picture.anchoredPosition == new Vector2(-75,-75))
            {
                PlayerOne.color = Image5.color;
            }
            else if (picture.anchoredPosition == new Vector2(-75,-150))
            {
                PlayerOne.color = Image8.color;
            }
            else if (picture.anchoredPosition == new Vector2(-150,0))
            {
                PlayerOne.color = Image1.color;
            }
            else if (picture.anchoredPosition == new Vector2(-150,-75))
            {
                PlayerOne.color = Image4.color;
            }
            else if (picture.anchoredPosition == new Vector2(-150,-150))
            {
                PlayerOne.color = Image7.color;
            }
        }   
        if (Input.GetKeyDown("m"))
        {
            TankChosen2 = true;
            RectTransform picture = PTwoSelect.GetComponent<RectTransform>();
            if (picture.anchoredPosition == new Vector2(0,0))
            {
                PlayerTwo.color = Image3.color;
            }
            else if (picture.anchoredPosition == new Vector2(0,-75))
            {
                PlayerTwo.color = Image6.color;
            }
            else if (picture.anchoredPosition == new Vector2(0,-150))
            {
                PlayerTwo.color = Image9.color;
            }
            else if (picture.anchoredPosition == new Vector2(-75,0))
            {
                PlayerTwo.color = Image2.color;
            }
            else if (picture.anchoredPosition == new Vector2(-75,-75))
            {
                PlayerTwo.color = Image5.color;
            }
            else if (picture.anchoredPosition == new Vector2(-75,-150))
            {
                PlayerTwo.color = Image8.color;
            }
            else if (picture.anchoredPosition == new Vector2(-150,0))
            {
                PlayerTwo.color = Image1.color;
            }
            else if (picture.anchoredPosition == new Vector2(-150,-75))
            {
                PlayerTwo.color = Image4.color;
            }
            else if (picture.anchoredPosition == new Vector2(-150,-150))
            {
                PlayerTwo.color = Image7.color;
            }
        }  
        if (TankChosen1 == true && TankChosen2 == true)
        {
            int number = Random.Range(1, 5);
            SceneManager.LoadScene (sceneName:"Map" + number.ToString());
        } 
    }

    
}
