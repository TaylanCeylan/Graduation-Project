using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 xInput { get; private set; }
    public bool IsJumped { get; set; }
    public bool IsCrouched { get; private set; }
    public bool IsShooting { get; set; }
    public bool IsPerformingMelee { get; set; }

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsShooting = true;
        }
        else
        {
            IsShooting=false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            IsPerformingMelee = true;
        }
        else
        {
            IsPerformingMelee=false;
        }
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        xInput = context.ReadValue<Vector2>();
    }

    public void JumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsJumped = true;
        }

        if (context.performed)
        {
            IsJumped = true;
            
        }

        if (context.canceled)
        {
            IsJumped = false;
        }
    }

    public void CrouchInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsCrouched = true;
        }

        if (context.performed)
        {
            IsCrouched = true;
        }

        if (context.canceled)
        {
            IsCrouched = false;
        }
    }

    public void MeleeInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsPerformingMelee = true;
        }

        if (context.canceled)
        {
            IsPerformingMelee = false;
        }
    }

}
