using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2D;

    [SerializeField] float xVelocity = 10f;
    [SerializeField] float jumpForce = 10f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.4f;
    [SerializeField] LayerMask whatIsGround;

    [SerializeField] Transform wallCheck;
    [SerializeField] float wallCheckRadius = 0.4f;

    [SerializeField] int health = 100;

    PlayerInputHandler inputHandler;
    PlayerMovements playerMovements;
    PlayerAnimations playerAnimations;

    Animator anim;

    int facingDirection;

    Vector2 input;

    bool isGrounded;
    bool isJumped;
    bool isTouchingWall;
    bool isCrouched;

    private void Awake()
    {
        playerMovements = new PlayerMovements();
        playerAnimations = new PlayerAnimations();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        inputHandler = GetComponent<PlayerInputHandler>();
        anim = GetComponent<Animator>();

        facingDirection = 1;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovements.MoveHorizontal(rb2D, input, xVelocity);
        playerMovements.Jump(isJumped, isGrounded, isTouchingWall, rb2D, jumpForce);
        playerMovements.WallSlide(rb2D, isGrounded, isTouchingWall, input);
        playerMovements.Crouch(rb2D, isGrounded, isCrouched);

        playerAnimations.SetAnimations(anim, input, isGrounded, isJumped, isTouchingWall, isCrouched, rb2D);

        CheckSurroundings();
        FlipPlayer();

        input = inputHandler.xInput;
        isJumped = inputHandler.IsJumped;
        isCrouched = inputHandler.IsCrouched;

    }

    void FlipPlayer()
    {
        if (input.x != 0 && input.x != facingDirection)
        {
            facingDirection *= -1;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe"))
        {
            health = health - 50;
        }

        if (collision.CompareTag("Arrow"))
        {
            health = health - 20;
        }

        if (collision.CompareTag("Melee"))
        {
            health = health - 100;
        }

        if (collision.CompareTag("Grenade"))
        {
            health = health - 100;
        }

        if (health == 0 || health < 0)
        {
            Destroy(gameObject);
        }
    }

    void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawWireSphere(wallCheck.position, wallCheckRadius);
    }

}
