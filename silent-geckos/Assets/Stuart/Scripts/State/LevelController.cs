using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	[SerializeField] private LevelState levelState;
    [SerializeField] private ScoreDataSO levelDataSO;
    [SerializeField] private ScoreDataSO cumulativeDataSO;


    private void Start()
	{
		LevelStart();
	}

	private void LevelStart()
	{
		levelState.SetIsGameStarted(true);
	}

	public void LevelEnd(bool isWin)
	{
		levelState.SetIsGameStarted(false);
        if (isWin)
        {
            Debug.Log("You win");
            cumulativeDataSO.UpdateScore(levelDataSO);
            levelDataSO.Clear();
        }
        else
        {
            Debug.Log("You Lose");
            levelDataSO.Clear();
        }

    }
}
