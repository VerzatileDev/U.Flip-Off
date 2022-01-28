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
	    Console.WriteLine("Open Settings");
	    mainMenuController.ShowSettings();
	    mainMenuController.HideMainMenu();

    }
    public void OnQuitButton()
    {
	    Console.WriteLine("Application quit");
	    Application.Quit();
    }
    public void OnStartGame()
    {
	    Console.WriteLine("Start Game");
	    SceneManager.LoadSceneAsync(1);
	    mainMenuController.HideMainMenu();
    }
}
