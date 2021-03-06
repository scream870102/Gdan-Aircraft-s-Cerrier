using Scream.UniMO;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using Lean.Pool;
using TMPro;

public class Bullet : MonoBehaviour, IControllable
{
    [SerializeField] float velocity = 0f;
    [SerializeField] Sprite normalSprite = null;
    [SerializeField] Sprite secondSprite = null;

    Rigidbody2D rb = null;
    Collider2D col = null;
    Transform tf = null;
    SpriteRenderer sr = null;
    GameObject owner = null;
    TextMeshPro bulletText = null;
    public bool IsEnable { get; private set; } = false;
    public bool IsUnderControll { get; set; }
    public bool IsReversed { get; private set; } = false;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        bulletText = GetComponentInChildren<TextMeshPro>();
        tf = gameObject.transform;
    }

    //呼叫這個函式讓玩家可以操作子彈
    public void EnableControll(bool isEnable, PlayerInput inputActions = null)
    {
        if (isEnable)
        {
            inputActions.GamePlay.Move.performed += HandleMovePerformed;
            IsUnderControll = true;
        }
        else
        {
            inputActions.GamePlay.Move.performed -= HandleMovePerformed;
            IsUnderControll = false;
        }
    }

    //呼叫這個函式設定子彈生成的初始位置跟速度
    public void EnableBullet(bool isEnable, GameObject owner = null, Vector2 direction = default, Vector2 position = default)
    {
        IsEnable = isEnable;
        this.owner = owner;
        if (IsEnable)
        {
            tf.position = position;
            Move(direction);
            IsReversed = false;
            sr.sprite = normalSprite;


        }
        else
        {
            rb.velocity = Vector2.zero;
            tf.position = position;
            LeanPool.Despawn(gameObject);
        }
    }


    //擊中任何的東西
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject != owner)
        {
            if (other.gameObject.GetComponent<Player>().IsInvi)
                return;
            DomainEvents.Raise(new OnBulletHit(other.gameObject));
            EnableBullet(false);
            FxController.Instance.SpawnSFX(SFXType.Damage);
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            EnableBullet(false);
        }
    }

    //回應子彈變形
    public void BulletDeform(bool isDeform)
    {
        if (isDeform) sr.sprite = secondSprite;
        else sr.sprite = normalSprite;
    }

    //反轉子彈的操作方向
    public void ReverseControllDirection()
    {
        IsReversed = !IsReversed;
    }

    //搖晃子彈
    public async UniTaskVoid PendulumBullet(float length, float offset)
    {
        float elapsed = 0f;
        float nextTime = elapsed + offset;
        while (elapsed <= length)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= nextTime)
            {
                var oldVel = rb.velocity.normalized;
                var y = Random.Range(-1f, 1f);
                oldVel.y = y;
                var newVel = oldVel.normalized;
                // var dir = Math.RandomVec2(1).normalized;
                // var vel = dir * velocity;
                rb.velocity = newVel * velocity;
                nextTime = elapsed + offset;
            }
            await UniTask.DelayFrame(1);
        }
    }

    //移動
    void Move(Vector2 direction)
    {
        var newVel = direction.normalized * velocity;
        rb.velocity = newVel;
    }

    //被操控的移動方式
    void HandleMovePerformed(InputAction.CallbackContext ctx)
    {
        var direction = ctx.ReadValue<Vector2>().normalized;
        var newVel = direction * velocity * (IsReversed ? -1f : 1f);
        if (rb) rb.velocity = newVel;

    }

    public void SetBulletText(string s)
    {
        if(bulletText) bulletText.text = s;
    }
}
