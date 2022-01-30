using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private CheckpointData checkPointdata;
    [SerializeField] private ScoreDataSO scoreDataSo;
    public bool inHell = false;
    public int checkpointnumber;
    public void Awake()
    {
        if (checkpointnumber == 1)
        {
            if (checkPointdata.checkpoint1 == true)
            {
                Destroy(gameObject);
            }
        }
        if (checkpointnumber == 2)
        {
            if (checkPointdata.checkpoint2 == true)
            {
                Destroy(gameObject);
            }
        }
        if (checkpointnumber == 3)
        {
            if (checkPointdata.checkpoint3 == true)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checkPointdata.SaveLocation(this.transform.position);
            checkPointdata.MergeData(scoreDataSo);
            checkPointdata.SaveCheckpoint(checkpointnumber);
            checkPointdata.inHell = inHell;
            Destroy(gameObject);
        }
    }
}
