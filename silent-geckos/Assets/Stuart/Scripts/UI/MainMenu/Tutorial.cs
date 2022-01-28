using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
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
            mainMenuController.HideTutorial();
        }
        else Debug.LogError("Main menu controller NULL");
		
    }
}
