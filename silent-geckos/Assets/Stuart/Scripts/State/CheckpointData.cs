using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CheckpointData", menuName = "Stuart/CheckpointData")]
public class CheckpointData : ScoreDataSO
{
    public Vector2 position;
    public bool checkpoint1 = false;
    public bool checkpoint2 = false;
    public bool checkpoint3 = false;




    public void MergeData(ScoreDataSO scoreDataSO)
    {
        heavenCoins = scoreDataSO.heavenCoins;
        hellCoins = scoreDataSO.hellCoins;
        progressBar = scoreDataSO.progressBar;
    }
    public void SaveLocation(Vector2 checkPosition)
    {
        position = checkPosition;
    }
    public void SaveCheckpoint(int checkpoint)
    {
        if (checkpoint == 1)
        {
            checkpoint1 = true;
        }
        if (checkpoint == 2)
        {
            checkpoint2 = true;
        }
        if (checkpoint == 3)
        {
            checkpoint3 = true;
        }
    }
    public void Wipe()
    {
        heavenCoins = 0;
        hellCoins = 0;
        progressBar = 0;
        position = Vector2.zero;
        checkpoint1 = false;
        checkpoint2 = false;
        checkpoint3 = false;
    }
}
