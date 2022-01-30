using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;

    public Transform firePoint;
    public GameObject bullet;
    float cooldownDuration = 0.75f;
    bool cooldown = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

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
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("ShootTrigger");
        yield return new WaitForSeconds(.15f);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(.1f);
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);
        cooldown = false;
    }
}
