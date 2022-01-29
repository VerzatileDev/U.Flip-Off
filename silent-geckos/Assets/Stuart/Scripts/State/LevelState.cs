
using System;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelStateData", menuName = "Stuart/LevelStateData")]
public class LevelState : ScriptableObject
{
    private bool isGameStarted = false;
    public event Action OnLevelStart;
    public event Action OnLevelEnd;

    private void OnEnable()
    {
        isGameStarted = false;
    }
    private void OnDisable()
    {
        isGameStarted = false;
    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }

    public void SetIsGameStarted(bool state)
    {
        if (state)
        {
            isGameStarted = true;
            OnLevelStart?.Invoke();
        }
        else
        {
            isGameStarted = false;
            OnLevelEnd?.Invoke();
        }
    }


}
