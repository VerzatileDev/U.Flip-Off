using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
   [SerializeField] private CanvasGroup LevelSelectCG;
   [SerializeField]private CanvasGroup MainMenuCG;
   [SerializeField]private CanvasGroup SettingsCG;
   private static readonly float AnimationTime = 0.5f;

    public void ShowLevelSelect() => StartCoroutine(ShowCanvas(LevelSelectCG, 1.0f));
    public void HideMainMenu() => StartCoroutine(ShowCanvas(MainMenuCG, 0.0f));
    public void ShowSettings() =>StartCoroutine(ShowCanvas(SettingsCG, 1.0f));
    
    
    private static IEnumerator ShowCanvas(CanvasGroup group, float target)
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
