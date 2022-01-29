using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlipScript : MonoBehaviour
{
    public GameObject player;
    public static bool GravityIsFlipped;
    public event Action<bool> OnPhaseChange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            Flip();
        }
    }

    void Flip()
    {
        isFlipped = !isFlipped;
        OnPhaseChange?.Invoke(!GravityisFlipped);
        Vector3 position = new Vector3(0, player.transform.position.y * -2,0);
        player.transform.Translate(position);
        player.GetComponent<Rigidbody2D>().velocity = new Vector3(player.GetComponent<Rigidbody2D>().velocity.x,player.GetComponent<Rigidbody2D>().velocity.y*-1,0);
        player.GetComponent<Rigidbody2D>().gravityScale *= -1;
        player.transform.localScale = new Vector3(1, player.transform.localScale.y * -1, 1);
    }
}
