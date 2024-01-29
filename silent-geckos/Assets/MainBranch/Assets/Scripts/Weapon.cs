using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;

    // Bullet related information
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
        // By Default the Shoot.isUnlocked is false and it has to be Gained
        // Currently it is set to true for testing purposes and should be fixed in the future
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
        // If the intance is not available stops all functionalities
        // Should not even use an instance here as its not in theory nessecary
        if (AudioController.instance != null)
        {
            AudioController.instance.PlaySFX(clip);
        }

        // Has issues required to be addressed in the future
        // When shooting it stops the player from moving currently it is disabled

        //player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("ShootTrigger");
        yield return new WaitForSeconds(.25f);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(.1f);
        //player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);
        cooldown = false;
    }
}
