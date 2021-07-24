using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Users;

public class Player : MonoBehaviour, IControllable
{
    public float MoveSpeed;
    public GameObject BulletPrefab;
    public float FireCd;
    public int BulletAmount;
    public float RadiusBetweenBullet;

    public InputUser InputUser {get; set;}
    public PlayerInput PlayerInput {get; set;}
    public PlayerMovement PlayerMovement {get; set;}
    public PlayerFire PlayerFire {get; set;}

    
    public bool IsUnderControll { get; set; }

    void Awake()
    {
        PlayerInput = new PlayerInput();
        PlayerInput.Enable();
        
        PlayerMovement = new PlayerMovement(this, MoveSpeed);
        PlayerFire = new PlayerFire(this, BulletPrefab, FireCd, BulletAmount, RadiusBetweenBullet);

        EnableControll(true, PlayerInput);
    }

    private void OnEnable() 
    {
        
    }

    private void OnDisable() 
    {
        PlayerInput.GamePlay.Bullet1.performed -= PlayerFire.HandleBullet1Control;
        PlayerInput.GamePlay.Bullet2.performed -= PlayerFire.HandleBullet2Control;
        PlayerInput.GamePlay.Bullet3.performed -= PlayerFire.HandleBullet3Control;
        PlayerInput.GamePlay.Bullet4.performed -= PlayerFire.HandleBullet4Control;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerInput.GamePlay.Bullet1.performed += PlayerFire.HandleBullet1Control;
        PlayerInput.GamePlay.Bullet2.performed += PlayerFire.HandleBullet2Control;
        PlayerInput.GamePlay.Bullet3.performed += PlayerFire.HandleBullet3Control;
        PlayerInput.GamePlay.Bullet4.performed += PlayerFire.HandleBullet4Control;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement.Move();
        PlayerFire.UpdateBullet();
    }



    public void EnableControll(bool isEnable, PlayerInput inputActions = null)
    {
        if (isEnable)
        {
            inputActions.GamePlay.Move.performed += PlayerMovement.OnMovementPerformed;
            PlayerInput.GamePlay.Move.canceled += PlayerMovement.OnMovementCanceled;
            IsUnderControll = true;
        }
        else
        {
            inputActions.GamePlay.Move.performed -= PlayerMovement.OnMovementPerformed;
            PlayerInput.GamePlay.Move.canceled -= PlayerMovement.OnMovementCanceled;
            PlayerMovement.Movement = Vector2.zero;
            IsUnderControll = false;
        }
    }

}
