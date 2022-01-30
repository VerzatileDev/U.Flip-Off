using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    [SerializeField] private AudioClip clip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            AudioController.instance.PlaySFX(clip);

            LevelController levelController = FindObjectOfType<LevelController>();
            if (levelController != null)
            {
                levelController.LevelEnd(true);
            }
            SceneManager.LoadScene("LevelEndMenu");
           
        }
    }
}
