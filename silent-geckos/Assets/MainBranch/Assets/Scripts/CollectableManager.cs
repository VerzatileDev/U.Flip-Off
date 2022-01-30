using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public int collectableValue = 1;
    public bool isGood = false;
    public bool isEvil = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isGood == true)
            {
                ScoreManager.instance.ChangeScoreGood(collectableValue);
                Destroy(gameObject);
                Destroy(transform.parent.gameObject);

            }
            if (isEvil == true)
            {
                ScoreManager.instance.ChangeScoreEvil(collectableValue);
                Destroy(gameObject);
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
