using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement
{
    public float moveSpeed;
    private Player player;
    private bool isLeft;
    public Vector2 Movement {get; set;}
    public bool IsReversed { get; private set; } = false;

    private Rigidbody2D rb;

    public PlayerMovement(Player player, float moveSpeed, bool isLeft)
    {
        this.player = player;
        this.moveSpeed = moveSpeed;
        this.isLeft = isLeft;

        rb = player.GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        if(rb) {
            rb.velocity = (IsReversed ? -Movement : Movement) * moveSpeed;
             
            if(rb.velocity.x != 0 || rb.velocity.y != 0) {
                player.PlayerAnimator.SetBool("IsMove", true);
                player.PlayerAnimator.SetFloat("MoveHorizontal", isLeft ? -rb.velocity.x : rb.velocity.x);
                player.PlayerAnimator.SetFloat("MoveVertical", rb.velocity.y);
            }
            else
            {
                player.PlayerAnimator.SetBool("IsMove", false);
            }
        }
        
    }

    public void OnMovementPerformed(InputAction.CallbackContext ctx)
    {
        Movement = ctx.ReadValue<Vector2>();
    }

    public void OnMovementCanceled(InputAction.CallbackContext ctx)
    {
        Movement = Vector2.zero;
    }

    public void ReverseControllDirection()
    {
        IsReversed = !IsReversed;
    }
}
