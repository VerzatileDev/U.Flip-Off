using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private AudioClip clip;

    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInformation)
    {
        if (hitInformation.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(OnDeath());
        }
    }

    IEnumerator OnDeath()
    {            AudioController.instance.PlaySFX(clip);

        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
