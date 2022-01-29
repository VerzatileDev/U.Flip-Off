using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    private float lifeTime = 1f;
    public Collider2D hitInformation;
    private void Awake()
    {
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed * GameObject.FindWithTag("EnemyRanged").transform.localScale.x / 5;
    }

    void OnTriggerEnter2D(Collider2D hitInformation)
    {
        if (hitInformation.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (!(hitInformation.gameObject.CompareTag("EnemyRanged") || hitInformation.gameObject.CompareTag("Enemy")))
        {
            Destroy(gameObject);
        }
    }
}
