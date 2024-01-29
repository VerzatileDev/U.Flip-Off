using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;

    public Transform firePoint;
    public GameObject bullet;
    float cooldownDuration = 0.9f;
    bool cooldown = false;

    [Header("Unlocks")] [SerializeField] private Unlock shootSpeed1;
    [SerializeField] private Unlock shootSpeed2;
    [SerializeField] private Unlock shoot;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        MovementSpeedUnlock();
        if ((Input.GetButtonDown("Fire1") || Input.GetKeyDown("k")) && shoot.isUnlocked)
        {
            if (cooldown == false)
            {
                StartCoroutine(Shoot());
                cooldown = true;
                StartCoroutine(Cooldown());
            }
        }
    }

    private void MovementSpeedUnlock()
    {
        if (shootSpeed1.isUnlocked) cooldownDuration = .75f;
        if (shootSpeed2.isUnlocked) cooldownDuration = .6f;
    }

    IEnumerator Shoot()
    {
        AudioController.instance.PlaySFX(clip);
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
