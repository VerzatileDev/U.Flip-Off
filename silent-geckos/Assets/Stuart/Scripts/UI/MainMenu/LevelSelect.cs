﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{    

    private MainMenuController mainMenuController;
    [SerializeField] private CheckpointData data;
    private void Awake()
    {
	    mainMenuController = GetComponentInParent<MainMenuController>();
    }

    public void OnBackButton()
    {
	    AudioController.instance.PlayButtonClick();

	    if (mainMenuController != null)
	    {
		    mainMenuController.ShowMainMenu();
		    mainMenuController.HideLevelSelect();
	    }
	    else Debug.LogWarning("Main menu controller NULL");
	    
    }

    public void OnLevelSelect(int level)
    {
	    AudioController.instance.PlayButtonClick();

	    if(level==0) Debug.LogError("Level number cannot be 0");
	    else if (SceneManager.sceneCount >= level)
	    {
		    WipeCheckPoints();
		    SceneManager.LoadSceneAsync(level+1);
	    }
	    else Debug.LogError("Level not available");

    }

    private void WipeCheckPoints()
    {
	   // data.Wipe();
    }
}
