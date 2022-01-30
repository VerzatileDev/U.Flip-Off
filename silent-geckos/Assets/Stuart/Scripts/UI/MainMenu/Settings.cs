using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
	[SerializeField] private AudioClip clip;

	private MainMenuController mainMenuController;

	private void Awake()
	{
		mainMenuController = GetComponentInParent<MainMenuController>();
	}

	public void OnBackButton()
	{
		AudioController.instance.PlaySFX(clip);

		if (mainMenuController != null)
		{
			mainMenuController.ShowMainMenu();
			mainMenuController.HideSettings();
		}
		else Debug.LogError("Main menu controller NULL");
		
	}
}