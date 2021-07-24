using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement
{
    public float moveSpeed;
    private Player player;
    public Vector2 Movement {get; set;}

    public PlayerMovement(Player player, float moveSpeed)
    {
        this.player = player;
        this.moveSpeed = moveSpeed;
    }

    public void Move()
    {
        player.transform.Translate(Movement * moveSpeed * Time.deltaTime);
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
