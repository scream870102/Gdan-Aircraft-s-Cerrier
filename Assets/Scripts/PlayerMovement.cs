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
        rb.velocity = Movement * moveSpeed;
        // player.transform.Translate(Movement * moveSpeed * Time.deltaTime);
    }

    public void OnMovementPerformed(InputAction.CallbackContext ctx)
    {
        Movement = ctx.ReadValue<Vector2>();
    }

    public void OnMovementCanceled(InputAction.CallbackContext ctx)
    {
        Movement = Vector2.zero;
    }

}
