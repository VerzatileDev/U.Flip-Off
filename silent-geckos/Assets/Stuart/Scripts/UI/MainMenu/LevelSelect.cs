using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    private MainMenuController mainMenuController;
    private void Awake()
    {
	    mainMenuController = GetComponentInParent<MainMenuController>();
    }

    public void OnBackButton()
    {
	    if (mainMenuController != null)
	    {
		    mainMenuController.ShowMainMenu();
		    mainMenuController.HideLevelSelect();
	    }
	    else Debug.LogWarning("Main menu controller NULL");
	    
    }

    public void OnLevelSelect(int level)
    {
	    
	    if(level==0) Debug.LogError("Level number cannot be 0");
	    else if(SceneManager.sceneCount>=level) SceneManager.LoadSceneAsync(level+1);
	    else Debug.LogError("Level not available");

    }
}
