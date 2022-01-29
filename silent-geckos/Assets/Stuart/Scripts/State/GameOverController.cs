using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private CumScoreData cumScoreData;

    private void Start()
    {
        throw new NotImplementedException();
    }

    public void OnBackButton()
    {
        cumScoreData.UpdateScore();

    }

    public void OnForwardButton()
    {
        cumScoreData.UpdateScore();
    }
}
