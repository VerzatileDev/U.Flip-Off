using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private CheckpointData checkPointdata;
    [SerializeField] private ScoreDataSO scoreDataSo;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (checkPointdata.checkpoint3 == true)
        {
            player.transform.position = checkPointdata.position;
            checkPointdata.Respawn(scoreDataSo);
        }
        else if (checkPointdata.checkpoint2 == true)
        {
            
        }

        else if (checkPointdata.checkpoint1 == true)
        {
            
        }
    }
}
