using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
   #region Variables
   [SerializeField] private CanvasGroup LevelSelectCG;
   [SerializeField]private CanvasGroup MainMenuCG;
   [SerializeField]private CanvasGroup SettingsCG;
   [SerializeField]private CanvasGroup TutorialCG;
   private static readonly float AnimationTime = .2f;
   [SerializeField] private LevelState levelState;
   #endregion
   
   #region ShowAndHideFunctions

   public void ShowLevelSelect() => StartCoroutine(ShowCanvas(LevelSelectCG, 1.0f));
    public void HideLevelSelect() => StartCoroutine(ShowCanvas(LevelSelectCG, 0.0f));

    public void HideMainMenu() => StartCoroutine(ShowCanvas(MainMenuCG, 0.0f));
    public void ShowMainMenu() => StartCoroutine(ShowCanvas(MainMenuCG, 1.0f));

    public void ShowSettings() =>StartCoroutine(ShowCanvas(SettingsCG, 1.0f));
    public void HideSettings() =>StartCoroutine(ShowCanvas(SettingsCG, 0.0f));
    public void ShowTutorial() =>StartCoroutine(ShowCanvas(TutorialCG, 1.0f));
    public void HideTutorial() =>StartCoroutine(ShowCanvas(TutorialCG, 0.0f));
    #endregion
    private void Awake()
    {
      
        //set initial states
        InitLoad(true, MainMenuCG);
        InitLoad(false, TutorialCG);
        InitLoad(false, SettingsCG);
        InitLoad(false, LevelSelectCG);

    }
    //sets state
    void InitLoad(bool state, CanvasGroup group)
    {
        group.interactable = state;
        group.blocksRaycasts = state;
        group.alpha = state ? 1 : 0;
        
    }
    //fades ui change
    public static IEnumerator ShowCanvas(CanvasGroup group, float target)
    {
        if (group == null) yield break;
        float startAlpha = group.alpha;
        float t = 0.0f;
        group.interactable = target >= 1.0f;
        group.blocksRaycasts = target >= 1.0f;

        while (t < AnimationTime)
        {
            t = Mathf.Clamp(t + Time.deltaTime, 0.0f, AnimationTime);
            group.alpha = Mathf.SmoothStep(startAlpha, target, t / AnimationTime);
            yield return null;
        }
    }
}
