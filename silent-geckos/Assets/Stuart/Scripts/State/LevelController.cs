using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class LevelController : MonoBehaviour
{
	[SerializeField] private LevelState levelState;
    [SerializeField] private ScoreDataSO levelDataSO;
    [SerializeField] private CumScoreData cumulativeDataSO;
    [SerializeField] private bool isWin;

    private void OnEnable()
    {
	    //ondeath+=HandleLevelDeath;
    }

    private void OnDisable()
    {
	    //ondeath-=HandleLevelDeath;
    }

    void HandleLevelDeath()
    {
	    LevelEnd(false);
    }
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
            cumulativeDataSO.isWin = true;
            cumulativeDataSO.lastLevel = levelDataSO;
            SceneManager.LoadSceneAsync(1);
        }
        else
        {
	        levelDataSO.Clear();
	        Debug.Log("You Lose");
          
        }

    }
}
