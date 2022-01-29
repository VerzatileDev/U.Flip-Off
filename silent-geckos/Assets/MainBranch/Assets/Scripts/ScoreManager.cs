using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public TextMeshProUGUI goodCounter;
    public TextMeshProUGUI evilCounter;
    int goodScore;
    int evilScore;

    public event Action<bool, int> OnCoinsChange;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void ChangeScoreGood(int coinValue)
    {
        goodScore += coinValue;
        goodCounter.text = goodScore.ToString();
        OnCoinsChange?.Invoke(true,coinValue);
    }
    public void ChangeScoreEvil(int coinValue)
    {
        evilScore += coinValue;
        evilCounter.text = evilScore.ToString();
        OnCoinsChange?.Invoke(false,coinValue);

    }
}