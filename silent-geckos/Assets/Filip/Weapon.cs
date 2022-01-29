using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    float cooldownDuration = 5f;
    bool cooldown = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("k"))
        {
            Shoot();
        }
    }
    void Shoot()

    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
