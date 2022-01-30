using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private MainMenuController mainMenuController;
    [SerializeField] private AudioClip clip;

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
            mainMenuController.HideTutorial();
        }
        else Debug.LogError("Main menu controller NULL");
		
    }
}
