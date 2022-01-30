using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] private CanvasGroup popup;
    public void Quit()
    {
        Debug.Log("Quiting");
        Application.Quit();
    }

    private void OnEnable()
    {
        Resume();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) TogglePause();
    }

    private void TogglePause()
    {
        if (isPaused) Resume();
        else Pause();
    }

    public void Resume()
    {
        popup.interactable = false;
        popup.blocksRaycasts = false;
        popup.alpha = 0;
        isPaused = false;
    }

    private void Pause()
    {
        popup.interactable = true;
        popup.blocksRaycasts = true;
        popup.alpha = 1; 
        isPaused = true;
    }
}
