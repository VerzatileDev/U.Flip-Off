using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    private float lifeTime = 10f;
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
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        if (rb.velocity.x > 0) this.transform.localScale = new Vector3(6, 6, 0);
        if (rb.velocity.x < 0) this.transform.localScale = new Vector3(-6, 6, 0);
    }

    void OnTriggerEnter2D(Collider2D hitInformation)
    {
        if (hitInformation.gameObject.CompareTag("Enemy"))
        {
            Destroy(hitInformation.gameObject);
            Destroy(gameObject);
        }
        else if (hitInformation.gameObject.CompareTag("EnemyRanged"))
        {
            // Not sure what the main indention was here, but I'm assuming it was to make the bullet disappear.
        }
        else if (!hitInformation.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
