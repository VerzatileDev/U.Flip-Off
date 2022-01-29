using UnityEngine;
using System; // For Action

public class FlipScript : MonoBehaviour
{
    [SerializeField] private GameObject player; // Hidden Globally, Shown In Inspector. ( Since not nessecary to Call it Anywhere Else as Generally Attached to Player Object )
    public static bool GravityIsFlipped;
    public event Action<bool> OnPhaseChange;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            Flip();
        }
    }

    void Flip()
    {
        GravityIsFlipped = !GravityIsFlipped;
        OnPhaseChange?.Invoke(!GravityIsFlipped);
        Vector3 position = new Vector3(0, player.transform.position.y * -2,0);
        player.transform.Translate(position);
        player.GetComponent<Rigidbody2D>().velocity = new Vector3(player.GetComponent<Rigidbody2D>().velocity.x,player.GetComponent<Rigidbody2D>().velocity.y*-1,0);
        player.GetComponent<Rigidbody2D>().gravityScale *= -1;
        player.transform.localScale = new Vector3(player.transform.localScale.x, player.transform.localScale.y * -1, 1);
    }
}
