using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float wallJumpForce = 8f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    private bool isTouchingWall;

    public Sprite idleSprite;
    public Sprite walkSprite;
    public Sprite jumpSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        if (moveX > 0) spriteRenderer.flipX = true;
        if (moveX < 0) spriteRenderer.flipX = false;

        // Regular jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Wall jump
        if (Input.GetButtonDown("Jump") && isTouchingWall && !isGrounded)
        {
            rb.linearVelocity = new Vector2(-moveX * wallJumpForce, jumpForce);
        }

        // Swap sprites
        if (!isGrounded)
            spriteRenderer.sprite = jumpSprite;
        else if (Mathf.Abs(moveX) > 0)
            spriteRenderer.sprite = walkSprite;
        else
            spriteRenderer.sprite = idleSprite;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            isTouchingWall = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            isTouchingWall = false;
        }
    }
}