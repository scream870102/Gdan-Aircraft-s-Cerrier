using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Users;

public class Player : MonoBehaviour
{
    public InputUser InputUser {get; set;}
    public PlayerInput PlayerInput {get; set;}

    PlayerMovement playerMovement = null;

    void Awake()
    {
        PlayerInput = new PlayerInput();
        PlayerInput.Enable();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement.Move();
    }
}
