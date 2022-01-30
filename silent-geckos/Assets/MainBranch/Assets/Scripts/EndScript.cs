using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LevelController levelController = FindObjectOfType<LevelController>();
            if (levelController != null)
            {
                levelController.LevelEnd(true);
            }
            SceneManager.LoadScene("LevelEndMenu");
           
        }
    }
}
