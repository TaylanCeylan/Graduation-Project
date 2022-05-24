using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations
{
    public void SetAnimations(Animator anim, Vector2 input, bool isGrounded, bool isJumping, bool isTouchingWall, bool isCrouching, bool isPerformingMelee, Rigidbody2D rb2D)
    {
        anim.SetFloat("yVelocity", rb2D.velocity.y);

        if (isGrounded)
        {
            if (isPerformingMelee)
            {
                anim.SetBool("melee", true);
            }
            else if (!isPerformingMelee)
            {
                anim.SetBool("melee", false);
            }

            if (input.x != 0)
            {
                anim.SetBool("crouch", false);
                anim.SetBool("wallSlide", false);
                anim.SetBool("inAir", false);
                anim.SetBool("idle", false);
                anim.SetBool("move", true);
            }

            if (input.x == 0 && isGrounded)
            {
                anim.SetBool("crouch", false);
                anim.SetBool("wallSlide", false);
                anim.SetBool("inAir", false);
                anim.SetBool("move", false);
                anim.SetBool("idle", true);
            }

            if (isCrouching)
            {
                anim.SetBool("wallSlide", false);
                anim.SetBool("inAir", false);
                anim.SetBool("idle", false);
                anim.SetBool("move", false);
                anim.SetBool("crouch", true);
            }
        }
        else if (!isGrounded)
        {
            if (isJumping)
            {
                anim.SetBool("crouch", false);
                anim.SetBool("wallSlide", false);
                anim.SetBool("idle", false);
                anim.SetBool("move", false);
                anim.SetBool("inAir", true);
            }

            if (isTouchingWall)
            {
                anim.SetBool("crouch", false);
                anim.SetBool("idle", false);
                anim.SetBool("move", false);
                anim.SetBool("inAir", false);
                anim.SetBool("wallSlide", true);
            }
            else if ((rb2D.velocity.y <= 0 || rb2D.velocity.y > 0.01) && !isTouchingWall)
            {
                anim.SetBool("wallSlide", false);
                anim.SetBool("inAir", true);
            }
        }
        
    }
}
