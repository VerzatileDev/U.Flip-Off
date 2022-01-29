using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Stuart/PlayerData")]
public class ScoreDataSO : ScriptableObject
{
    public int heavenCoins=0;
    public int hellCoins = 0;
    public float progressBar = 0;
    

    public void Clear()
    {
        heavenCoins =0;
        hellCoins=0;
        progressBar=0;
    }


    public void UpdateCoins(bool b, int score)
    {
        if (b) heavenCoins = score;
        else hellCoins = score;
    }
}
