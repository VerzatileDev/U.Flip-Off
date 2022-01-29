using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeScreen : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameOverUIController gameOverUIController;
    public void OnBackButton()
    {
        StartCoroutine( MainMenuController.ShowCanvas(gameOverUIController.gameOverScreen, 1f));
        StartCoroutine(MainMenuController.ShowCanvas(gameOverUIController.upgradeScreen, 0f));

    }

    public void OnForwardButton()
    {
        SceneManager.LoadSceneAsync(0);

    }
}
