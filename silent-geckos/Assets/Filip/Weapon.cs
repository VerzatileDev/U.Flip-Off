using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
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
