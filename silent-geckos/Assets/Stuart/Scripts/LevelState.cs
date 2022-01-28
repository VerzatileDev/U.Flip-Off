
using System;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelStateData", menuName = "LevelStateData")]
public class LevelState : ScriptableObject
{
    private bool isGameStarted = false;
    public event Action OnLevelStart;
    public event Action OnLevelEnd;

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
