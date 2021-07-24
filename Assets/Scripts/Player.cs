using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Users;
using Scream.UniMO;

public class Player : MonoBehaviour, IControllable
{
    public float MoveSpeed;
    public GameObject BulletPrefab;
    public float FireCd;
    public int BulletAmount;
    public float RadiusBetweenBullet;
    public float ReverseCd;

    public InputUser InputUser {get; set;}
    public PlayerInput PlayerInput {get; set;}
    public PlayerMovement PlayerMovement {get; set;}
    public PlayerFire PlayerFire {get; set;}

    private bool isLeft;
    
    public bool IsUnderControll { get; set; }

    void Awake()
    {
        PlayerInput = new PlayerInput();
        PlayerInput.Enable();

        isLeft = transform.position.x > 0 ? true : false;
        
        PlayerMovement = new PlayerMovement(this, MoveSpeed, isLeft);
        PlayerFire = new PlayerFire(this, BulletPrefab, FireCd, BulletAmount, RadiusBetweenBullet, ReverseCd, isLeft);

        EnableControll(true, PlayerInput);
    }

    private void OnEnable() 
    {
        PlayerInput.GamePlay.Bullet1.performed += PlayerFire.HandleBullet1Control;
        PlayerInput.GamePlay.Bullet2.performed += PlayerFire.HandleBullet2Control;
        PlayerInput.GamePlay.Bullet3.performed += PlayerFire.HandleBullet3Control;
        PlayerInput.GamePlay.Bullet4.performed += PlayerFire.HandleBullet4Control;

        DomainEvents.Register<OnBulletHit>(HandleBulletHit);
        DomainEvents.Register<OnItemGet>(HandleItemGet);
    }

    private void OnDisable() 
    {
        PlayerInput.GamePlay.Bullet1.performed -= PlayerFire.HandleBullet1Control;
        PlayerInput.GamePlay.Bullet2.performed -= PlayerFire.HandleBullet2Control;
        PlayerInput.GamePlay.Bullet3.performed -= PlayerFire.HandleBullet3Control;
        PlayerInput.GamePlay.Bullet4.performed -= PlayerFire.HandleBullet4Control;

        DomainEvents.UnRegister<OnBulletHit>(HandleBulletHit);
        DomainEvents.UnRegister<OnItemGet>(HandleItemGet);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement.Move();
        PlayerFire.UpdateBullet();

        Debug.Log(PlayerFire.GetBullet());
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

    void HandleBulletHit(OnBulletHit e)
    {
        if (e.Target == gameObject)
        {
            //ATTEND: GameOver 要呼叫OnPlayerDead
            DomainEvents.Raise(new OnPlayerDead(null));
        }
    }


    void HandleItemGet(OnItemGet e)
    {
        if (e.Getter == gameObject)
        {
            Debug.Log($"Get Item {e.Type.ToString()}");
        }
    }

}
