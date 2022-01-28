using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
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
			mainMenuController.HideSettings();
		}
		else Debug.LogWarning("Main menu controller NULL");
		
	}
}