using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dash : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private bool isDashOnCooldown = false;
    [SerializeField] private Unlock dashUnlock;
    [SerializeField] static public bool isMovementEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l") && !isDashOnCooldown && dashUnlock.isUnlocked)
        {
            StartCoroutine(DashCR());
        }
    }

    IEnumerator DashCR()
    {
        isDashOnCooldown = true;
        float temp = player.GetComponent<Rigidbody2D>().gravityScale;
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        isMovementEnabled = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector3(player.transform.localScale.x * 4, 0, 0);
        yield return new WaitForSeconds(.2f);
        player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        player.GetComponent<Rigidbody2D>().gravityScale = temp;
        isMovementEnabled = true;
        yield return new WaitForSeconds(.8f);
        isDashOnCooldown = false;
    }
}
