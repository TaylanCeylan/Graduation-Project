using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulldozer : MonoBehaviour
{
    [SerializeField] int health;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask whatIsGround;

    [SerializeField] Transform wallCheck;
    [SerializeField] float wallCheckRadius;

    [SerializeField] Transform playerCheck;
    [SerializeField] LayerMask whatIsPlayer;
    [SerializeField] float playerCheckRadius;

    [SerializeField] Transform attackRange;
    [SerializeField] float attackRangeRadius;

    [SerializeField] Transform playerCheck2;


    bool isGrounded;
    bool isFacingWall;
    bool isFacingRight = true;
    bool isPlayerDetected;
    bool isPlayerInRange;

    Transform target;

    Animator anim;

    Rigidbody2D rb2D;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        health = 100;
    }

    private void Update()
    {
        CheckSurroundings();
        EnemyPatrol();
        CheckIfShouldFlip();
    }

    void EnemyPatrol()
    {

        if (!isPlayerDetected)
        {
            anim.SetBool("attack", false);
            anim.SetBool("run", false);
            anim.SetBool("idle", true);
        }
        else if (isPlayerDetected && !isPlayerInRange)
        {
            float step = 5f * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, target.position, step);

            anim.SetBool("attack", false);
            anim.SetBool("idle", false);
            anim.SetBool("run", true);
        }
        else if (isPlayerInRange)
        {
            anim.SetBool("idle", false);
            anim.SetBool("run", false);
            anim.SetBool("attack", true);
        }

        if (!isGrounded || isFacingWall)
        {
            if (isFacingRight == true)
            {
                transform.Rotate(0, 180, 0);
                isFacingRight = false;
            }
            else if (isFacingRight == false)
            {
                transform.Rotate(0, 180, 0);
                isFacingRight = true;
            }
        }
    }

    private void TakeDamage()
    {
        health = health - 20;

        if (health == 0 || health < 0)
        {
            Destroy(gameObject);
        }
    }

    void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isFacingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsGround);
        isPlayerDetected = Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, whatIsPlayer) || 
            Physics2D.OverlapCircle(playerCheck2.position, playerCheckRadius, whatIsPlayer);
        isPlayerInRange = Physics2D.OverlapCircle(attackRange.position, attackRangeRadius, whatIsPlayer);
    }

    void CheckIfShouldFlip()
    {
        if (Vector3.Distance(target.position, transform.position) < 20)
        {
            if (target.position.x > transform.position.x && !isFacingRight)
                Flip();
            if (target.position.x < transform.position.x && isFacingRight)
                Flip();
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        isFacingRight = !isFacingRight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet")) { TakeDamage(); }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawWireSphere(wallCheck.position, wallCheckRadius);
        Gizmos.DrawWireSphere(playerCheck.position, playerCheckRadius);
        Gizmos.DrawWireSphere(playerCheck2.position, playerCheckRadius);
        Gizmos.DrawWireSphere(attackRange.position, attackRangeRadius);
    }
}
