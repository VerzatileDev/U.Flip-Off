using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverUIController : MonoBehaviour
{
    public CanvasGroup gameOverScreen;
   public CanvasGroup upgradeScreen;

   private void Start()
   {
       StartCoroutine(MainMenuController.ShowCanvas(gameOverScreen, 1f));
       StartCoroutine(MainMenuController.ShowCanvas(upgradeScreen, 0f));
       
   }
}
