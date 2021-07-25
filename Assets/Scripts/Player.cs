using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Users;
using Scream.UniMO;
using UnityEngine.UI;

public class Player : MonoBehaviour, IControllable
{
    public bool ActivePlayer;
    public float MoveSpeed;
    public GameObject BulletPrefab;
    public float FireCd;
    public int BulletAmount;
    public float RadiusBetweenBullet;
    public float ReverseCd;
    public PlayerIconControl PlayerIconControl;
    public Animator PlayerAnimator;

    public InputUser InputUser {get; set;}
    public PlayerInput PlayerInput {get; set;}
    public PlayerMovement PlayerMovement {get; set;}
    public PlayerFire PlayerFire {get; set;}
    public PlayerItemHandler PlayerItemHandler {get; set;}

    private bool isLeft;
    public bool IsInvi = false;
    public bool IsDeform = false;
    public ItemType CurrentItem = ItemType.Empty;
    public bool IsUnderControll { get; set; }
    [SerializeField]bool control;

    void Awake()
    {
        ActivePlayer = false;

        PlayerInput = new PlayerInput();
        PlayerInput.Enable();

        isLeft = transform.position.x > 0 ? true : false;
        
        PlayerMovement = new PlayerMovement(this, MoveSpeed, isLeft);
        PlayerFire = new PlayerFire(this, BulletPrefab, FireCd, BulletAmount, RadiusBetweenBullet, ReverseCd, isLeft);
        PlayerItemHandler = new PlayerItemHandler(this);

        EnableControll(true, PlayerInput);
    }

    private void OnEnable() 
    {
        PlayerInput.GamePlay.Bullet1.performed += PlayerFire.HandleBullet1Control;
        PlayerInput.GamePlay.Bullet2.performed += PlayerFire.HandleBullet2Control;
        PlayerInput.GamePlay.Bullet3.performed += PlayerFire.HandleBullet3Control;
        PlayerInput.GamePlay.Bullet4.performed += PlayerFire.HandleBullet4Control;

        PlayerInput.GamePlay.Item.performed += PlayerItemHandler.OnItemPerformed;

        DomainEvents.Register<OnBulletHit>(HandleBulletHit);
        DomainEvents.Register<OnItemGet>(HandleItemGet);
    }

    private void OnDisable() 
    {
        PlayerInput.GamePlay.Bullet1.performed -= PlayerFire.HandleBullet1Control;
        PlayerInput.GamePlay.Bullet2.performed -= PlayerFire.HandleBullet2Control;
        PlayerInput.GamePlay.Bullet3.performed -= PlayerFire.HandleBullet3Control;
        PlayerInput.GamePlay.Bullet4.performed -= PlayerFire.HandleBullet4Control;

        PlayerInput.GamePlay.Item.performed -= PlayerItemHandler.OnItemPerformed;

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
        if(ActivePlayer)
        {
            PlayerMovement.Move();
            PlayerFire.UpdateBullet();
            control = IsUnderControll;
        }
    }



    public void EnableControll(bool isEnable, PlayerInput inputActions = null)
    {
        if (isEnable)
        {
            inputActions.GamePlay.Move.performed += PlayerMovement.OnMovementPerformed;
            inputActions.GamePlay.Move.canceled += PlayerMovement.OnMovementCanceled;
            IsUnderControll = true;
        }
        else
        {
            inputActions.GamePlay.Move.performed -= PlayerMovement.OnMovementPerformed;
            inputActions.GamePlay.Move.canceled -= PlayerMovement.OnMovementCanceled;
            PlayerMovement.Movement = Vector2.zero;
            IsUnderControll = false;
        }
    }

    void HandleBulletHit(OnBulletHit e)
    {
        if (e.Target == gameObject)
        {
            //ATTEND: GameOver 要呼叫OnPlayerDead
            DomainEvents.Raise(new OnPlayerDead(this));
        }
    }


    void HandleItemGet(OnItemGet e)
    {
        if (e.Getter == gameObject)
        {
            Debug.Log($"Get Item {e.Type.ToString()}");
            CurrentItem = e.Type;
            PlayerIconControl.ChangeIcon(e.Type);
        }
        PlayerItemHandler.AutoUseDebuffItem(e.Type);
    }

}
