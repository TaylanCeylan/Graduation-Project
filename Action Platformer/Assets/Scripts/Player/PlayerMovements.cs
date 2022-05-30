using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements
{
    public void MoveHorizontal(Rigidbody2D rb2D, Vector2 input, float velocity)
    {
        rb2D.velocity = new Vector2(input.x * velocity, rb2D.velocity.y);
    }

    public void Jump(bool isJumped, bool isGrounded, bool isTouchingWall, Rigidbody2D rb2D, float jumpForce)
    {
        if ((isJumped && isGrounded ) || isTouchingWall)
        {
            rb2D.velocity = Vector2.up * jumpForce;
        }

    }

    public void WallSlide(Rigidbody2D rb2D, bool isGrounded, bool isTouchingWall, Vector2 input)
    {
        if (!isGrounded && isTouchingWall && rb2D.velocity.y < 0)
        {
            rb2D.velocity = -Vector2.up;
        }
    }

    public void Crouch(Rigidbody2D rb2D, bool isGrounded, bool isCrouched)
    {
        if (isGrounded && isCrouched)
        {
            rb2D.velocity = new Vector2(0, 0);
        }
    }

}
