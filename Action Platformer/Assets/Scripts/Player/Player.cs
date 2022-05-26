using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] public int health = 100;

    [SerializeField] public int playerCoins = 0;

    public HealthBar healthBar;

    [HideInInspector]
    public int currentHealth;

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
    bool isPerformingMelee;
    bool isShooting;

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

        currentHealth = health;
        healthBar.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        playerMovements.MoveHorizontal(rb2D, input, xVelocity);
        playerMovements.Jump(isJumped, isGrounded, isTouchingWall, rb2D, jumpForce);
        playerMovements.WallSlide(rb2D, isGrounded, isTouchingWall, input);
        playerMovements.Crouch(rb2D, isGrounded, isCrouched);

        playerAnimations.SetAnimations(anim, input, isGrounded, isJumped, isTouchingWall, isCrouched, isPerformingMelee, isShooting, rb2D);

        CheckSurroundings();
        FlipPlayer();

        input = inputHandler.xInput;
        isJumped = inputHandler.IsJumped;
        isCrouched = inputHandler.IsCrouched;
        isPerformingMelee = inputHandler.IsPerformingMelee;
        isShooting = inputHandler.IsShooting;

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
            currentHealth = currentHealth - 50;
        }

        if (collision.CompareTag("Arrow"))
        {
            currentHealth = currentHealth - 20;
        }

        if (collision.CompareTag("Melee"))
        {
            currentHealth = currentHealth - 100;
        }

        if (collision.CompareTag("Grenade"))
        {
            currentHealth = currentHealth - 100;
        }

        if (collision.CompareTag("HealthPotion"))
        {
            currentHealth = currentHealth + 50;
        }

        if (collision.CompareTag("Flame"))
        {
            currentHealth = currentHealth - 5;
        }

        if (collision.CompareTag("Portal"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (currentHealth == 0 || currentHealth < 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        healthBar.SetHealth(currentHealth);

        if (currentHealth > health)
        {
            currentHealth = health;
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
