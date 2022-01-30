using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

	private MainMenuController mainMenuController;
	private void Awake()=> mainMenuController = GetComponentInParent<MainMenuController>();
	[SerializeField] private CheckpointData data;

	public void OnLevelSelectButton()
	{
		AudioController.instance.PlayButtonClick();

		Console.WriteLine("Open Level Select");
		mainMenuController.ShowLevelSelect();
		mainMenuController.HideMainMenu();
	}
    public void OnSettingsButton()
    {
	    AudioController.instance.PlayButtonClick();

	    Debug.Log("Open Settings");
	    mainMenuController.ShowSettings();
	    mainMenuController.HideMainMenu();

    }
    public void OnTutorialButton()
    {
	    AudioController.instance.PlayButtonClick();

	    Debug.Log("Open Tutorial");
	    mainMenuController.ShowTutorial();
	    mainMenuController.HideMainMenu();

    }
    public void OnQuitButton()
    {
	    AudioController.instance.PlayButtonClick();

	    Debug.Log("Application quit");
	    Application.Quit();
    }
    public void OnStartGame()
    {
	    AudioController.instance.PlayButtonClick();

	    Debug.Log("Start Game");
	    WipeCheckPoints();
	    SceneManager.LoadSceneAsync(2);
	    mainMenuController.HideMainMenu();
    }
    private void WipeCheckPoints()
    {
	   data.Wipe();
    }
}
