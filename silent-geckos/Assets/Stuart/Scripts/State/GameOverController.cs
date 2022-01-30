using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] GameOverUIController gameOverUIController;
    public void OnBackButton()
    {
        Debug.LogWarning("back button pressed");
        AudioController.instance.PlayButtonClick();
        SceneManager.LoadSceneAsync(0);
    }

    public void OnForwardButton()
    {
        AudioController.instance.PlayButtonClick();

        StartCoroutine( MainMenuController.ShowCanvas(gameOverUIController.gameOverScreen, 0f));
        StartCoroutine(  MainMenuController.ShowCanvas(gameOverUIController.upgradeScreen, 1f));

    }

    
}
