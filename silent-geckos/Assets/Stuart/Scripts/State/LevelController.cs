using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
	[SerializeField] private LevelState levelState;
    [SerializeField] private ScoreDataSO levelDataSO;
    [SerializeField] private CumScoreData cumulativeDataSO;


    private void Start()
	{
		LevelStart();
	}

	private void LevelStart()
	{
		levelState.SetIsGameStarted(true);
		cumulativeDataSO.lastLevel = levelDataSO;
	}

	public void LevelEnd(bool isWin)
	{
		levelState.SetIsGameStarted(false);
        if (isWin)
        {
            Debug.Log("You win");
            cumulativeDataSO.lastLevel = levelDataSO;
            SceneManager.LoadSceneAsync(0);
        }
        else
        {
	        levelDataSO.Clear();
	        cumulativeDataSO.lastLevel = levelDataSO;
	        Debug.Log("You Lose");
            SceneManager.LoadSceneAsync(0);
        }

    }
}
