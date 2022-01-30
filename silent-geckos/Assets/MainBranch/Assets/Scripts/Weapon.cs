using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public Transform firePoint;
    public GameObject bullet;
    float cooldownDuration = 0.5f;
    bool cooldown = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("k"))
        {
            if (cooldown == false)
            {
                StartCoroutine(Shoot());
                cooldown = true;
                StartCoroutine(Cooldown());
            }
        }
    }
    IEnumerator Shoot()
    {
        animator.SetTrigger("ShootTrigger");
        yield return new WaitForSeconds(.15f);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);
        cooldown = false;
    }
}
