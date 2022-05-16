using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game2Control : MonoBehaviour
{
    public GameObject[] characters2;
    public Transform player2StartPosition;
    private string selected2CharacterDataName = "Selected2Character";
    public int selected2Character;
    public GameObject player2Object;
    public GameObject TPCDP1Icon;
    public GameObject TPCDP2Icon;
    public GameObject AICDP1Icon;
    public GameObject AICDP2Icon;

    public GameObject SNTankCDIcon1;
    public GameObject SNTankCDIcon2;

    public GameObject BMTankCDIcon1;
    public GameObject BMTankCDIcon2;

    public GameObject SHTankCDIcon1;
    public GameObject SHTankCDIcon2;

    // Start is called before the first frame update
    void Start()
    {

        selected2Character = PlayerPrefs.GetInt(selected2CharacterDataName,0);

        characters2[selected2Character].SetActive(true);
        player2Object = Instantiate(characters2[selected2Character],player2StartPosition.position, characters2[selected2Character].transform.rotation);
        player2Object.GetComponent<TankScript>().isPlayer2Input = true;
        player2Object.tag = "Player2";


        if (selected2Character == 0)
        {
            TPCDP2Icon.SetActive(true);
        }

        else if (selected2Character == 2)
        {
            AICDP2Icon.SetActive(true);
        }

        else if (selected2Character == 5)
        {
            BMTankCDIcon2.SetActive(true);
        }

        else if (selected2Character == 6)
        {
            SNTankCDIcon2.SetActive(true);
        }

        else if (selected2Character == 9)
        {
            SHTankCDIcon2.SetActive(true);
        }
    }
}
