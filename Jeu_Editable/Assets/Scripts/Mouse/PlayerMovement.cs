using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float airMoveSpeedMultiplier = 0.5f; // Multiplicateur de vitesse de déplacement lorsque le joueur est en l'air

    public bool isGrounded;
    public Transform groundCheck;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private bool isJumping = false;
    private float horizontalMovement;

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f);

        horizontalMovement = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
        }

        if(!isGrounded )
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void FixedUpdate()
    {
        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        float currentMoveSpeed = moveSpeed;

        // Si le joueur est en l'air, réduire la vitesse de déplacement
        if (!isGrounded)
        {
            currentMoveSpeed *= airMoveSpeedMultiplier;
        }

        Vector2 targetVelocity = new Vector2(_horizontalMovement * currentMoveSpeed, rb.velocity.y);
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, 0.1f);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
