using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccuracyApplier : MonoBehaviour
{
    public int shotsfired_player1;
    public int shotsfired_player2;

    public int shots_hit_player1;
    public int shots_hit_player2;
    public Text Player1_hitShots_Text;
    public Text Player2_hitShots_Text;
    public Text Player1_FiredShots_Text;
    public Text Player2_FiredShots_Text;
    private GameObject AccuracyTracker;
    // Update is called once per frame
    void Start()
    {
        AccuracyTracker = GameObject.Find("AccuracyTracker");
        UpdateTexts();
    }

    void UpdateTexts()
    {
        shotsfired_player1 = AccuracyTracker.GetComponent<Accuracy>().shotsfired_player1;
        shotsfired_player2 = AccuracyTracker.GetComponent<Accuracy>().shotsfired_player2;

        shots_hit_player1 = AccuracyTracker.GetComponent<Accuracy>().shots_hit_player1;
        shots_hit_player2 = AccuracyTracker.GetComponent<Accuracy>().shots_hit_player2;
    }

    void Update()
    {

        Player1_hitShots_Text.text = "Shots Hit: " + shots_hit_player1.ToString();
        Player2_hitShots_Text.text = "Shots Hit: " + shots_hit_player2.ToString();

        Player1_FiredShots_Text.text = "Shots Fired: " + shotsfired_player1.ToString();
        Player2_FiredShots_Text.text = "Shots Fired: " + shotsfired_player2.ToString();
    }
}
