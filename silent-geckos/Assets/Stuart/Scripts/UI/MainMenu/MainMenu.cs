using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
	private MainMenuController mainMenuController;
	private void Awake()=> mainMenuController = GetComponentInParent<MainMenuController>();
	
	public void OnLevelSelectButton()
	{
		Console.WriteLine("Open Level Select");
		mainMenuController.ShowLevelSelect();
		mainMenuController.HideMainMenu();
	}
    public void OnSettingsButton()
    {
	    Debug.Log("Open Settings");
	    mainMenuController.ShowSettings();
	    mainMenuController.HideMainMenu();

    }
    public void OnTutorialButton()
    {
	    Debug.Log("Open Tutorial");
	    mainMenuController.ShowTutorial();
	    mainMenuController.HideMainMenu();

    }
    public void OnQuitButton()
    {
	    Debug.Log("Application quit");
	    Application.Quit();
    }
    public void OnStartGame()
    {
	    Debug.Log("Start Game");
	    SceneManager.LoadSceneAsync(1);
	    mainMenuController.HideMainMenu();
    }
}
