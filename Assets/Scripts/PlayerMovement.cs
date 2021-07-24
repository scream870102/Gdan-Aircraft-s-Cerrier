using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Player Player;
    public Vector2 Movement {get; private set;}

    void OnEnable()
    {
        Player.PlayerInput.GamePlay.Move.performed += OnMovementPerformed;
        Player.PlayerInput.GamePlay.Move.canceled += OnMovementCanceled;
        Debug.Log(Player);
        Debug.Log(Player.PlayerInput.GamePlay);
    }

    void OnDisable()
    {
        Player.PlayerInput.GamePlay.Move.performed -= OnMovementPerformed;
        Player.PlayerInput.GamePlay.Move.canceled -= OnMovementCanceled;
    }

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        transform.Translate(Movement * moveSpeed * Time.deltaTime);
    }

    private void OnMovementPerformed(InputAction.CallbackContext ctx)
    {
        Movement = ctx.ReadValue<Vector2>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext ctx)
    {
        Movement = Vector2.zero;
    }
}
