using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Respawn : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private CheckpointData checkPointdata;
    [SerializeField] private ScoreDataSO scoreDataSo;
    public TextMeshProUGUI goodCounter;
    public TextMeshProUGUI evilCounter;
    private int goodScore = 0;
    private int evilScore = 0;

    public event Action OnRespawn;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (checkPointdata.checkpoint3 == true)
        {
            player.transform.position = checkPointdata.position;
            checkPointdata.Respawn(scoreDataSo);
            Debug.Log("3");
            goodScore += scoreDataSo.heavenCoins;
            goodCounter.text = goodScore.ToString();
            evilScore += scoreDataSo.hellCoins;
            evilCounter.text = evilScore.ToString();
            OnRespawn?.Invoke();
            if (checkPointdata.inHell == true)
            {
                player.GetComponent<Rigidbody2D>().gravityScale *= -1;
                player.transform.localScale = new Vector3(player.transform.localScale.x, player.transform.localScale.y * -1, 1);
                FlipScript.GravityIsFlipped = true;
            }
        }
        else if (checkPointdata.checkpoint2 == true)
        {
            player.transform.position = checkPointdata.position;
            checkPointdata.Respawn(scoreDataSo);
            Debug.Log("2");
            goodScore += scoreDataSo.heavenCoins;
            goodCounter.text = goodScore.ToString();
            evilScore += scoreDataSo.hellCoins;
            evilCounter.text = evilScore.ToString();
            OnRespawn?.Invoke();
            if (checkPointdata.inHell == true)
            {
                player.GetComponent<Rigidbody2D>().gravityScale *= -1;
                player.transform.localScale = new Vector3(player.transform.localScale.x, player.transform.localScale.y * -1, 1);
                FlipScript.GravityIsFlipped = true;
            }
        }

        else if (checkPointdata.checkpoint1 == true)
        {
            player.transform.position = checkPointdata.position;
            checkPointdata.Respawn(scoreDataSo);
            Debug.Log("1");
            goodScore += scoreDataSo.heavenCoins;
            goodCounter.text = goodScore.ToString();
            evilScore += scoreDataSo.hellCoins;
            evilCounter.text = evilScore.ToString();
            OnRespawn?.Invoke();
            if (checkPointdata.inHell == true)
            {
                player.GetComponent<Rigidbody2D>().gravityScale *= -1;
                player.transform.localScale = new Vector3(player.transform.localScale.x, player.transform.localScale.y * -1, 1);
                FlipScript.GravityIsFlipped = true;
            }
        }
    }
}
