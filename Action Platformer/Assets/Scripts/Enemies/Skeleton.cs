using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour 
{   
    [SerializeField] int health;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask whatIsGround;

    [SerializeField] Transform wallCheck;
    [SerializeField] float wallCheckRadius;

    [SerializeField] LayerMask whatIsPlayer;


    bool isGrounded;
    bool isFacingWall;
    bool isFacingRight = true;
    bool isPlayerDetected;

    Transform target;

    Animator anim;

    Rigidbody2D rb2D;

    void Start()
    {
        anim = GetComponent<Animator>();

        rb2D = GetComponent<Rigidbody2D>();

        health = 100;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    private void Update()
    {
        CheckSurroundings();
        EnemyPatrol();
    }

    void EnemyPatrol()
    {

        if (!isPlayerDetected)
        {
            transform.Translate(Vector2.right * 5f * Time.deltaTime);
            
            anim.SetBool("attack", false);
            
            anim.SetBool("walk", true);
        }
        else if (isPlayerDetected)
        {
            anim.SetBool("walk", false);
            anim.SetBool("attack", true);
        }

        if (!isGrounded || isFacingWall)
        {
            if (isFacingRight == true)
            {
                transform.Rotate(0, 180, 0);
                isFacingRight = false;
            }
            else
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
        isPlayerDetected = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsPlayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet")) { TakeDamage(); }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawWireSphere(wallCheck.position, wallCheckRadius);
    }
}