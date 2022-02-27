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
        RectTransform picture2 = PTwoSelect.GetComponent<RectTransform>();
        if (picture2.anchoredPosition == new Vector2(0,0))
        {
            PlayerTwo.sprite = GilTank;
            PlayerTwoTxt.text = "Jaiden's child that shootz out tree shells at the same time, is biased off of gilgameesh and dose 2 much dmg 😭. If u no beet dem, join em....";
        }
        else if (picture2.anchoredPosition == new Vector2(-75,0))
        {
            PlayerTwo.sprite = TeleportTank;
            PlayerTwoTxt.text = "tank that ignores psykicks and coliders resulting in the ultimait kenbunshoku haki 💨. (21skimask, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21)";
        }
        else if (picture2.anchoredPosition == new Vector2(-150,0))
        {
            PlayerTwo.sprite = AIBombTank;
            PlayerTwoTxt.text = "i shoot bulet, bulet folows u, tick tick tick BOOOOOMMMMMMMMMMMMMMMMM! i no move; i stil win L.";
        }
        else if (picture2.anchoredPosition == new Vector2(-150,-75))
        {
            PlayerTwo.sprite = SummonTank;
            PlayerTwoTxt.text = "sumoning the dead lik im orochimaru, think that you safe imma chase you lik karoo, thought you would win imma go prove you wrong, ambassador of the dead singin this lil song.";
        }
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
            // else if (picture.anchoredPosition == new Vector2(0,-75))
            // {
            //     PlayerOne.color = Image6.color;
            // }
            // else if (picture.anchoredPosition == new Vector2(0,-150))
            // {
            //     PlayerOne.color = Image9.color;
            // }
            // else if (picture.anchoredPosition == new Vector2(-75,-75))
            // {
            //     PlayerOne.color = Image5.color;
            // }
            // else if (picture.anchoredPosition == new Vector2(-75,-150))
            // {
            //     PlayerOne.color = Image8.color;
            // }
            // else if (picture.anchoredPosition == new Vector2(-150,-150))
            // {
            //     PlayerOne.color = Image7.color;
            // }
        }   
        if (Input.GetKeyDown("m"))
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
            // else if (picture.anchoredPosition == new Vector2(0,-75))
            // {
            //     PlayerTwo.color = Image6.color;
            // }
            // else if (picture.anchoredPosition == new Vector2(0,-150))
            // {
            //     PlayerTwo.color = Image9.color;
            // }
            // else if (picture.anchoredPosition == new Vector2(-75,-75))
            // {
            //     PlayerTwo.color = Image5.color;
            // }
            // else if (picture.anchoredPosition == new Vector2(-75,-150))
            // {
            //     PlayerTwo.color = Image8.color;
            // }
            // else if (picture.anchoredPosition == new Vector2(-150,-150))
            // {
            //     PlayerTwo.color = Image7.color;
            // }
        }  
        if (TankChosen1 == true && TankChosen2 == true)
        {
            int number = Random.Range(1, 5);
            SceneManager.LoadScene (sceneName:"Map" + number.ToString());
        } 
    }

    
}
