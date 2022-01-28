using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D PlayerBody;

    //Forces
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    //Direction
    private bool facingRight = true;
    private float moveDirection;

    //Collision Checking
    private bool isJumping = false;
    private bool isGrounded;
    public float checkRadius;
    [SerializeField] private Transform ceilingCheck;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundObjects;

    [SerializeField] private int jumpCount;
    [SerializeField] private int maxJumpCount;

    // [SerializeField]  - Serialize Field, gives the opperatunity to Load and Save your values given..( as well as see them In the Inspector)
    // [Tooltip("text")] - Hovering over the Element in the Inspector Shows What the value is Used for Or its Information nessecary
    // Debug.Log("text"); - Tell us Information within the Console

    private void Start()
    {
        jumpCount = maxJumpCount;
    }

    private void Awake()
    {
        // "At Start of the Game "Gets a component and Attaches it to rigidbody2d
        PlayerBody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Processinputs();
        Animate();
    }
    //Called multiples time per frame
    private void FixedUpdate()
    {
        // Check Ground Position With A Circle Radius from GroundObjects
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        if (isGrounded)
        {
            jumpCount = maxJumpCount; //While user on the Floor, possible Jumps is set back to Maximum amount.
        }
        Move();
    }

    private void Move()
    {
        PlayerBody.velocity = new Vector2(moveDirection * moveSpeed, PlayerBody.velocity.y);
        if (isJumping)
        {
            PlayerBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpCount--;
        }
        isJumping = false;
    }

    private void Processinputs()
    {
        moveDirection = Input.GetAxis("Horizontal"); // Scale of -1 to 1
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            isJumping = true;
        }
    }

    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight; // Inverse bool
        transform.Rotate(0f, 180f, 0f);
    }
}
