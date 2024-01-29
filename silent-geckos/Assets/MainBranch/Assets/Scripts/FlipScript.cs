using System.Collections;
using UnityEngine;
using System;

public class FlipScript : MonoBehaviour
{
    [SerializeField] private AudioClip clip;

    [SerializeField] private GameObject player; // Hidden Globally, Shown In Inspector. ( Since not nessecary to Call it Anywhere Else as Generally Attached to Player Object )
    public static bool GravityIsFlipped;
    public event Action<bool> OnPhaseChange;
    private bool isFlipOnCooldown = false;
    private bool isFlipEnabled;
    [SerializeField] private CheckpointData checkPointdata;

    void Start()
    {
        GravityIsFlipped = false;
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        isFlipEnabled = Dash.isMovementEnabled;
        if (Input.GetKeyDown("f") && !isFlipOnCooldown && isFlipEnabled)
        {
            Flip();
            
        }
    }

    public void Flip()
    {
        StartCoroutine(FlipCooldown());
        if (AudioController.instance != null)
        {
            AudioController.instance.PlaySFX(clip);
            AudioController.instance.CrossFade();
        }
        
        GravityIsFlipped = !GravityIsFlipped;
        OnPhaseChange?.Invoke(!GravityIsFlipped);
        Vector3 position = new Vector3(0, player.transform.position.y * -2, 0);
        player.transform.Translate(position);
        player.GetComponent<Rigidbody2D>().velocity = new Vector3(player.GetComponent<Rigidbody2D>().velocity.x, player.GetComponent<Rigidbody2D>().velocity.y * -1, 0);
        player.GetComponent<Rigidbody2D>().gravityScale *= -1;
        player.transform.localScale = new Vector3(player.transform.localScale.x, player.transform.localScale.y * -1, 1);
        
    }

    IEnumerator FlipCooldown()
    {
        isFlipOnCooldown = true;
        yield return new WaitForSeconds(.5f);
        isFlipOnCooldown = false;
    }
}
