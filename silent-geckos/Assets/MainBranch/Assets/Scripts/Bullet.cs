using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    private float lifeTime = 1f;
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
        rb.velocity = transform.right * speed * GameObject.FindWithTag("Player").transform.localScale.x/5;
    }

    void OnTriggerEnter2D(Collider2D hitInformation)
    {
        if (hitInformation.gameObject.CompareTag("Enemy"))
        {
            Destroy(hitInformation.gameObject);
            Destroy(gameObject);
        }
        else if (!hitInformation.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
