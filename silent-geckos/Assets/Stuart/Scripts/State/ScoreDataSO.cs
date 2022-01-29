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

    private void OnEnable()
    {
        ScoreManager.instance.OnCoinsChange += ReceiveCoins;
    }

    private void ReceiveCoins(bool arg1, int arg2)
    {
        if (arg1) heavenCoins += arg2;
        else hellCoins += arg2;
    }

    private void OnDisable()
    {
        ScoreManager.instance.OnCoinsChange -= ReceiveCoins;
    }

    public void Clear()
    {
        heavenCoins =0;
        hellCoins=0;
        progressBar=0;
    }
    
    
}
