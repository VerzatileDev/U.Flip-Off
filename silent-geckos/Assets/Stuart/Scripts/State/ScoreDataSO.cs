using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData")]
public class ScoreDataSO : ScriptableObject
{
    public int heavenCoins=0;
    public int hellCoins = 0;
    public float progressBar = 0;

    public void UpdateScore(ScoreDataSO so)
    {
        heavenCoins += so.heavenCoins;
        hellCoins += so.hellCoins;
        progressBar += so.progressBar;
    }

    public void Clear()
    {
        heavenCoins =0;
        hellCoins=0;
        progressBar=0;
    }
}
