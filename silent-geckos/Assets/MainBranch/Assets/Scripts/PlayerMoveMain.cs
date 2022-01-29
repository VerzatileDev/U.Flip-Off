using UnityEngine;

public class PlayerMoveMain : MonoBehaviour
{
    private Rigidbody2D PlayerBody;

    [Header("Set Player Forces")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;

    [Header("Player Collision Checks")]
    //[SerializeField] private Transform ceilingCheck; // -- State not used ! -- //
    //[SerializeField] private Transform groundCheck;

    [Header("Define Collision Layer to Check")]
    [SerializeField] private LayerMask jumpableObjects;

    [Header("Player Jump Information")]
    [SerializeField] private int maxJumpCount;
    [SerializeField] private int jumpsAvailable;
    [Tooltip("Makes A circle with Radius : __ :  From   groundCheck  and check if Radius Inside or Touching jumpableObjects ")]
    [SerializeField] private float checkRadius;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isJumping = false;
    [SerializeField] private bool isMovementEnabled;

    //[Header("Player Direction")]
    private bool facingRight = true;
    private float moveDirection;
    private bool gravityState; // Gets GravityisFlipped State
    private float value;

    // [SerializeField]  - See Private Values Within The Inspector Editor
    // [Header("Text")]  - Organizes Inspector into a list seperating other values where nessecary
    // [Tooltip("text")] - Hover Over an Element Such as Variable, States Its use as A TextBox Tooltip on top of the Value.
    // Debug.Log("text"); - Displays Information Within our Console

    private void Awake()
    {
        PlayerBody = GetComponent<Rigidbody2D>();
        jumpsAvailable = maxJumpCount;
    }

    void Update() // Once per frame
    {
        Processinputs();
        Animate();
    }

    private void Processinputs()
    {
        isMovementEnabled = Dash.isMovementEnabled;
        gravityState = FlipScript.GravityIsFlipped;
        moveDirection = Input.GetAxis("Horizontal"); // Scale of -1 to 1
        if (Input.GetButtonDown("Jump") && (jumpsAvailable > 0 || isGrounded))
        {
            isJumping = true;
        }
    }

    private void FixedUpdate() //Called multiples time per frame
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, checkRadius, jumpableObjects);
        if (isGrounded && !isJumping)
        {
            jumpsAvailable = maxJumpCount;
        }
        Move();
    }

    private void Move()
    {
        if (isMovementEnabled)
        {
            PlayerBody.velocity = new Vector2(moveDirection * movementSpeed, PlayerBody.velocity.y);
            if (isJumping)
            {
                if (gravityState) value = -jumpForce; else value = jumpForce;
                PlayerBody.AddForce(new Vector2(0f, value), ForceMode2D.Impulse);
                jumpsAvailable--;
                isJumping = false;
            }
        }
    }



    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipPlayerDirection();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipPlayerDirection();
        }
    }

    private void FlipPlayerDirection()
    {
        facingRight = !facingRight; // Inverse bool
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
    }
}
