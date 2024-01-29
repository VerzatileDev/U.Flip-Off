using System.Collections;
using UnityEngine;

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

    void Start()
    {
        rb.velocity = transform.right * speed * GameObject.FindWithTag("EnemyRanged").transform.localScale.x / -5;
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
