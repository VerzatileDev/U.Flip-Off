using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CumusScoreData", menuName = "Stuart/CumusScoreData")]

public class CumScoreData : ScoreDataSO
{
    public ScoreDataSO lastLevel;
    public bool isWin;
    public void UpdateScore()
    {
        if (lastLevel == null)
        {
            Debug.LogWarning("No last score data");
            lastLevel.Clear();
            return;
        }
        heavenCoins += lastLevel.heavenCoins;
        hellCoins += lastLevel.hellCoins;
        progressBar += lastLevel.progressBar;
        lastLevel.Clear();
    }
}
