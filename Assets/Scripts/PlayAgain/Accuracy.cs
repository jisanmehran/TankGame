using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accuracy : MonoBehaviour
{
    public int shotsfired_player1 = 1;
    public int shotsfired_player2 = 1;

    public int shots_hit_player1;
    public int shots_hit_player2;

    public float Player1_Accuracy;
    public float Player2_Accuracy;

    public void AddShotPlayer1()
    {
        shotsfired_player1++;
    }

    public void AddShotPlayer2()
    {
        shotsfired_player2++;
    }
}
