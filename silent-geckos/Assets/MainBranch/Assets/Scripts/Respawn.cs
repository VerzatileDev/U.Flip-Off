using System;
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

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // Check if the game is starting fresh
        bool isFreshStart = GameManager.IsFreshStart;

        if (isFreshStart)
        {
            // Set IsFreshStart to false to indicate that the game is not starting fresh next time
            GameManager.IsFreshStart = false;
            // Set the player's initial position when starting the game fresh
            checkPointdata.Wipe();
            if (player != null)
            {
                player.transform.position = GameManager.InitialPlayerPosition;
            }
            else
            {
                Debug.LogError("Player GameObject not found.");
            }
        }
        else
        {
            if (player != null && checkPointdata != null)
            {
                RespawnPlayerAtCheckpoint();
            }
            else
            {
                Debug.LogError("Player or CheckpointData is not properly initialized.");
            }
        }

    }

    private void RespawnPlayerAtCheckpoint()
    {

        if (checkPointdata.checkpoint3 == true)
        {
            player.transform.position = checkPointdata.position;
            checkPointdata.Respawn(scoreDataSo);
            Debug.Log("3");
            goodScore += scoreDataSo.heavenCoins;
            if (goodCounter != null) // Becasue stupid bug
            {
                goodCounter.text = goodScore.ToString();
            }
            evilScore += scoreDataSo.hellCoins;
            if (evilCounter != null)
            {
                evilCounter.text = evilScore.ToString();
            }
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
            if (goodCounter != null)
            {
                goodCounter.text = goodScore.ToString();
            }
            evilScore += scoreDataSo.hellCoins;
            if (evilCounter != null)
            {
                evilCounter.text = evilScore.ToString();
            }
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
            if (goodCounter != null)
            {
                goodCounter.text = goodScore.ToString();
            }
            evilScore += scoreDataSo.hellCoins;
            if( evilCounter != null)
            {
                evilCounter.text = evilScore.ToString();
            }
            OnRespawn?.Invoke();
            if (checkPointdata.inHell == true)
            {
                player.GetComponent<Rigidbody2D>().gravityScale *= -1;
                player.transform.localScale = new Vector3(player.transform.localScale.x, player.transform.localScale.y * -1, 1);
                FlipScript.GravityIsFlipped = true;
            }
        }
    }


    public static class GameManager
    {
        public static bool IsFreshStart { get; set; } = true;
        public static Vector3 InitialPlayerPosition { get; set; } = new Vector3(68.2f, 6.3f, 479.6003f);
    }

}