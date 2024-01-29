using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] private CanvasGroup popup;
    [SerializeField] private AudioClip clip;

    // SCENES to load
    [SerializeField] private Object mainMenuScene;

    public void toMainMenu()
    {
        Time.timeScale = 1f; // Ensure time scale is set to normal speed before loading the new scene

        if (mainMenuScene != null && mainMenuScene is SceneAsset)
        {
            SceneAsset sceneAsset = (SceneAsset)mainMenuScene;
            string sceneName = sceneAsset.name;
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Main menu scene is not assigned or is not a valid SceneAsset.");
        }

    }

    private void OnEnable()
    {
        Resume();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else Pause();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        popup.interactable = false;
        popup.blocksRaycasts = false;
        popup.alpha = 0;
        isPaused = false;
    }

    private void Pause()
    {
        AudioController.instance.PlaySFX(clip);
        Time.timeScale = 0f;
        popup.interactable = true;
        popup.blocksRaycasts = true;
        popup.alpha = 1; 
        isPaused = true;
    }
}
