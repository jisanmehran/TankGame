using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game2Control : MonoBehaviour
{
    public GameObject[] characters;
    public Transform player2StartPosition;
    private string selected2CharacterDataName = "Selected2Character";
    public int selected2Character;
    public GameObject player2Object;


    // Start is called before the first frame update
    void Start()
    {
        selected2Character = PlayerPrefs.GetInt(selected2CharacterDataName,0);
        player2Object = Instantiate(characters[selected2Character],player2StartPosition.position,characters[selected2Character].transform.rotation);
        player2Object.GetComponent<TankScript>().isPlayer2Input = true;
        player2Object.tag = "Player2";
    }
}
