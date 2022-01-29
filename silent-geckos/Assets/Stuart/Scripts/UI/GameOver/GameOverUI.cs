using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameOverUI : MonoBehaviour
{
    [SerializeField] private CumScoreData cumScoreData;
    [SerializeField] private TextMeshProUGUI heavenCoins;
    [SerializeField] private TextMeshProUGUI hellCoins;
    [SerializeField] private TextMeshProUGUI heavenProgress;
    [SerializeField] private TextMeshProUGUI hellProgress;
    [SerializeField] private TextMeshProUGUI winLose;

    private void Start()
    {
        UpdateScreen();
    }

    private void UpdateScreen()
    {
        if (cumScoreData == null)
        {
            Debug.LogWarning("no score data");
            return;
        }

        if (cumScoreData.lastLevel == null)
        {
            SetLose();
            return;
        }

        SetWin();

    }

    private void SetWin()
    {
        winLose.text = "You win";
        hellCoins.text = cumScoreData.lastLevel.hellCoins.ToString();
        heavenCoins.text = cumScoreData.lastLevel.heavenCoins.ToString();
        hellProgress.text = (100-((int)(cumScoreData.lastLevel.progressBar*100))).ToString();
        heavenProgress.text = ((int)(cumScoreData.lastLevel.progressBar*100)).ToString();
        cumScoreData.UpdateScore();
    }

    private void SetLose()
    {
        hellCoins.text = "0";
        heavenCoins.text = "0";
        hellProgress.text = "0";
        heavenProgress.text = "0";
        winLose.text = "You lose";
    }
}
