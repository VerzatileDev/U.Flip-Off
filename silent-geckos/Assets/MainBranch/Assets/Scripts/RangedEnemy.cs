using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField] private bool isInRange = false;
    [SerializeField] private bool cooldown = false;
    [SerializeField] private float cooldownDuration = 3f;
    public GameObject bullet;
    public Transform firePoint;
    public Collider2D other;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
    void Update()
    {
        if (isInRange == true)
        {
            if (cooldown == false)
            {
                Shoot();
                cooldown = true;
                StartCoroutine(Cooldown());
            }
        }
    }
    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);
        cooldown = false;
    }
}
