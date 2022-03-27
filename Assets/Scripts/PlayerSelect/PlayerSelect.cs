using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerSelect : MonoBehaviour
{
    public float toplimit = 0f;
    public Image POneSelect;
    public Image PTwoSelect;
    public bool TankChosen1;
    public bool TankChosen2;

    public string Level;
    public Image PlayerOne;
    public Image PlayerTwo;
    public Text PlayerOneTxt;
    public Text PlayerTwoTxt;
    public Image Image1;
    public Image Image2;
    public Image Image3;
    public Image Image4;
    public Image Image5;
    public Image Image6;
    public Image Image7;
    public Image Image8;
    public Image Image9;
    public Sprite GilTank;
    public Sprite SummonTank;
    public Sprite AIBombTank;
    public Sprite TeleportTank;
    public AudioClip PlayerSelection;


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

        RectTransform picture1 = POneSelect.GetComponent<RectTransform>();

        if (picture1.anchoredPosition == new Vector2(0,0))
        {
            PlayerOne.sprite = GilTank;
            PlayerOneTxt.text = "Gilgamesh Tank - Tank with three barrels that shoots are three bullets at the same time, but has a slower fire rate than the others.";
        }

        else if (picture1.anchoredPosition == new Vector2(-75,0))
        {
            PlayerOne.sprite = TeleportTank;
            PlayerOneTxt.text = "Teleport Tank - Tank that can phase through the walls and bullets for 5 seconds, and is able to dash away to safety.";
        }

        else if (picture1.anchoredPosition == new Vector2(-150,0))
        {
            PlayerOne.sprite = AIBombTank;
            PlayerOneTxt.text = "AI Bomb Tank - Tank that summons autotracking drones which follow you unti blown up; whether you shoot it or not.";
        }

        else if (picture1.anchoredPosition == new Vector2(-150,-75))
        {
            PlayerOne.sprite = SummonTank;
            PlayerOneTxt.text = "Summoner Tank - Tank that summons smaller tank which act as turrets, but can also be controlled by the player leaving the main tank defenseless.";
        }

        RectTransform picture2 = PTwoSelect.GetComponent<RectTransform>();

        if (picture2.anchoredPosition == new Vector2(0,0))
        {
            PlayerTwo.sprite = GilTank;
            PlayerTwoTxt.text = "Gilgamesh Tank - Tank with three barrels that shoots are three bullets at the same time, but has a slower fire rate than the others.";
        }

        else if (picture2.anchoredPosition == new Vector2(-75,0))
        {
            PlayerTwo.sprite = TeleportTank;
            PlayerTwoTxt.text = "Teleport Tank - Tank that can phase through the walls and bullets for 5 seconds, and is able to dash away to safety.";
        }

        else if (picture2.anchoredPosition == new Vector2(-150,0))
        {
            PlayerTwo.sprite = AIBombTank;
            PlayerTwoTxt.text = "AI Bomb Tank - Tank that summons autotracking drones which follow you unti blown up; whether you shoot it or not.";
        }

        else if (picture2.anchoredPosition == new Vector2(-150,-75))
        {
            PlayerTwo.sprite = SummonTank;
            PlayerTwoTxt.text = "Summoner Tank - Tank that summons smaller tank which act as turrets, but can also be controlled by the player leaving the main tank defenseless.";
        }

        if (TankChosen1 == false) 
        {
            if(Input.GetKeyDown("up"))
            {
                RectTransform picture = POneSelect.GetComponent<RectTransform>();
                if (picture.anchoredPosition.y <= toplimit)
                {
                    picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y+75);
                    AudioSource audio = gameObject.GetComponent<AudioSource>();
                    audio.clip = PlayerSelection;
                    audio.Play();
                }     
            }
            else if(Input.GetKeyDown("left"))
            {
                RectTransform picture = POneSelect.GetComponent<RectTransform>();
                if (picture.anchoredPosition.x != -150)
                {
                    picture.anchoredPosition = new Vector2(picture.anchoredPosition.x-75, picture.anchoredPosition.y);
                    AudioSource audio = gameObject.GetComponent<AudioSource>();
                    audio.clip = PlayerSelection;
                    audio.Play();
                }          
            }
            else if (Input.GetKeyDown("down"))
            {
                RectTransform picture = POneSelect.GetComponent<RectTransform>();
                if (picture.anchoredPosition.y > -150)
                {
                    picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y-75);
                    AudioSource audio = gameObject.GetComponent<AudioSource>();
                    audio.clip = PlayerSelection;
                    audio.Play();
                }
            
            }
            else if (Input.GetKeyDown("right"))
            {
                RectTransform picture = POneSelect.GetComponent<RectTransform>();
                if (picture.anchoredPosition.x != 0)
                {
                    picture.anchoredPosition = new Vector2(picture.anchoredPosition.x+75, picture.anchoredPosition.y);
                    AudioSource audio = gameObject.GetComponent<AudioSource>();
                    audio.clip = PlayerSelection;
                    audio.Play();
                }         
            }
        }

        if (TankChosen2 == false) 
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                RectTransform picture = PTwoSelect.GetComponent<RectTransform>();
                if (picture.anchoredPosition.y <= toplimit)
                {
                    picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y+75);
                    AudioSource audio = gameObject.GetComponent<AudioSource>();
                    audio.clip = PlayerSelection;
                    audio.Play();
                }
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                RectTransform picture = PTwoSelect.GetComponent<RectTransform>();
                if (picture.anchoredPosition.x != -150)
                {
                    picture.anchoredPosition = new Vector2(picture.anchoredPosition.x-75, picture.anchoredPosition.y);
                    AudioSource audio = gameObject.GetComponent<AudioSource>();
                    audio.clip = PlayerSelection;
                    audio.Play();
                }
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                RectTransform picture = PTwoSelect.GetComponent<RectTransform>();
                if (picture.anchoredPosition.y > -150)
                {
                    picture.anchoredPosition = new Vector2(picture.anchoredPosition.x, picture.anchoredPosition.y-75);
                    AudioSource audio = gameObject.GetComponent<AudioSource>();
                    audio.clip = PlayerSelection;
                    audio.Play();
                }
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                RectTransform picture = PTwoSelect.GetComponent<RectTransform>();
                if (picture.anchoredPosition.x != 0)
                {
                    picture.anchoredPosition = new Vector2(picture.anchoredPosition.x+75, picture.anchoredPosition.y);
                    AudioSource audio = gameObject.GetComponent<AudioSource>();
                    audio.clip = PlayerSelection;
                    audio.Play();
                } 
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) | Input.GetKeyDown(KeyCode.RightControl))
        {
            //Image3 is giltank
            //Image2 is tptank
            //Image1 is Aibombtank
            //Image4 is summontank
            RectTransform picture = POneSelect.GetComponent<RectTransform>();
            if (picture.anchoredPosition == new Vector2(0,0))
            {
                PlayerOne.color = Image3.color;
                TankChosen1 = true;
            }
            else if (picture.anchoredPosition == new Vector2(-75,0))
            {
                PlayerOne.color = Image2.color;
                TankChosen1 = true;
            }
            else if (picture.anchoredPosition == new Vector2(-150,0))
            {
                PlayerOne.color = Image1.color;
                TankChosen1 = true;
            }
            else if (picture.anchoredPosition == new Vector2(-150,-75))
            {
                PlayerOne.color = Image4.color;
                TankChosen1 = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            
            RectTransform picture = PTwoSelect.GetComponent<RectTransform>();
            if (picture.anchoredPosition == new Vector2(0,0))
            {
                PlayerTwo.color = Image3.color;
                TankChosen2 = true;
            }
            else if (picture.anchoredPosition == new Vector2(-150,0))
            {
                PlayerTwo.color = Image1.color;
                TankChosen2 = true;
            }
            else if (picture.anchoredPosition == new Vector2(-150,-75))
            {
                PlayerTwo.color = Image4.color;
                TankChosen2 = true;
            }
            else if (picture.anchoredPosition == new Vector2(-75,0))
            {
                PlayerTwo.color = Image2.color;
                TankChosen2 = true;
            }
        }  
    }
}