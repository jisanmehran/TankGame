using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MapSelect : MonoBehaviour
{
    public Image POneSelect;
    public bool TankChosen1;

    public string Level;
    public Image PlayerOne;
    //public Image PlayerTwo;
    public Text PlayerOneTxt;
    //public Text PlayerTwoTxt;
    public Image Image1;
    public Image Image2;
    public Image Image3;
    public Sprite GilTank;
    public Sprite SummonTank;
    public Sprite AIBombTank;
    public Sprite TeleportTank;
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
            PlayerOne.sprite = GilTank;
            PlayerOneTxt.text = "Jaiden's child that shootz out tree shells at the same time, is biased off of gilgameesh and dose 2 much dmg 😭. If u no beet dem, join em....";
        }
        else if (picture1.anchoredPosition == new Vector2(-75,0))
        {
            PlayerOne.sprite = TeleportTank;
            PlayerOneTxt.text = "tank that ignores psykicks and coliders resulting in the ultimait kenbunshoku haki 💨. (21skimask, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21)";
        }
        else if (picture1.anchoredPosition == new Vector2(-150,0))
        {
            PlayerOne.sprite = AIBombTank;
            PlayerOneTxt.text = "i shoot bulet, bulet folows u, crack ba BOOOOOMMMMMMMMMMMMMMMMM! i no move; i stil win L.";
        }
        else if (picture1.anchoredPosition == new Vector2(-150,-75))
        {
            PlayerOne.sprite = SummonTank;
            PlayerOneTxt.text = "sumoning the dead lik im orochimaru, think that you safe imma chase you lik karoo, thought you would win imma go prove you wrong, ambassador of the dead singin this lil song.";
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