using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MapSelect : MonoBehaviour
{
    
    //public Image PlayerOne;
    //public Image PlayerTwo;
    //public Text PlayerTwoTxt;
    // public Image Image1;
    // public Image Image2;
    // public Image Image3;
    public Text PlayerOneTxt;
    public Image POneSelect;
    public bool TankChosen1;
    public string Level;
    public RawImage PlayerRawOne;
    public Texture Map1;
    public Texture Map3;
    public Texture Map2;
    public AudioClip MapSelection;


    // Start is called before the first frame update
    void Start()
    {
        TankChosen1 = false;
    }

    // Update is called once per frame
    void Update()
    {

        RectTransform picture1 = POneSelect.GetComponent<RectTransform>();
        if (picture1.anchoredPosition == new Vector2(0,0))
        {
            PlayerRawOne.texture = Map3;
            PlayerOneTxt.text = "This is the third map which has three rotating walls in the middle.";
        }
        else if (picture1.anchoredPosition == new Vector2(-75,0))
        {
            PlayerRawOne.texture = Map2;
            PlayerOneTxt.text = "This is the second map which has four walls going up and down.";
        }
        else if (picture1.anchoredPosition == new Vector2(-150,0))
        {
            PlayerRawOne.texture = Map1;
            PlayerOneTxt.text = "This is the first map which has many barriers and is the best map to start with.";
        }

        if (TankChosen1 == false) 
        {

            if(Input.GetKeyDown("d"))
            {
                RectTransform picture = POneSelect.GetComponent<RectTransform>();

                if (picture.anchoredPosition.x != -150)
                {
                    picture.anchoredPosition = new Vector2(picture.anchoredPosition.x-75, picture.anchoredPosition.y);
                }
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = MapSelection;
                audio.Play();
            }

            else if (Input.GetKeyDown("left"))
            {
                RectTransform picture = POneSelect.GetComponent<RectTransform>();

                if (picture.anchoredPosition.x != -150)
                {
                    picture.anchoredPosition = new Vector2(picture.anchoredPosition.x-75, picture.anchoredPosition.y);
                }        
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = MapSelection;
                audio.Play();
            }

            else if (Input.GetKeyDown("g"))
            {
                RectTransform picture = POneSelect.GetComponent<RectTransform>();

                if (picture.anchoredPosition.x != 0)
                {
                    picture.anchoredPosition = new Vector2(picture.anchoredPosition.x+75, picture.anchoredPosition.y);
                }         
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = MapSelection;
                audio.Play();
            }

            else if (Input.GetKeyDown("right"))
            {
                RectTransform picture = POneSelect.GetComponent<RectTransform>();

                if (picture.anchoredPosition.x != 0)
                {
                    picture.anchoredPosition = new Vector2(picture.anchoredPosition.x+75, picture.anchoredPosition.y);
                }   

                AudioSource audio = gameObject.GetComponent<AudioSource>();
                audio.clip = MapSelection;
                audio.Play();
            }
        }
    }
}