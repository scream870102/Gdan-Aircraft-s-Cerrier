using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using Scream.UniMO;
#if UNITY_EDITOR
using Scream.UniMO.Editor;
#endif
using Lean.Pool;

public class TmpPlayer : MonoBehaviour
{
    PlayerInput input = null;
    [SerializeField] GameObject prefab = null;
    [ReadOnly, SerializeField] List<Bullet> bullets = null;
    void Awake()
    {
        input = new PlayerInput();
        input.GamePlay.Enable();
        bullets = new List<Bullet>();

    }


    void Start()
    {

    }


    void OnEnable()
    {
        input.GamePlay.Bullet1.performed += HandleBtnConfirmed;
        input.GamePlay.Move.performed += HandleMovePerformed;
        DomainEvents.Register<OnBulletHit>(HandleBulletHit);
        DomainEvents.Register<OnItemGet>(HandleItemGet);
    }


    void OnDisable()
    {
        input.GamePlay.Bullet1.performed -= HandleBtnConfirmed;
        input.GamePlay.Move.performed -= HandleMovePerformed;
        DomainEvents.UnRegister<OnBulletHit>(HandleBulletHit);
        DomainEvents.UnRegister<OnItemGet>(HandleItemGet);
    }


    async void HandleBtnConfirmed(InputAction.CallbackContext ctx)
    {
        foreach (var b in bullets)
        {
            b.BulletDeform();
        }
        if (bullets.Count == 0)
        {
            var obj = LeanPool.Spawn(prefab, transform);
            var bullet = obj.GetComponent<Bullet>();
            var dir = Math.RandomVec2(1f).normalized;
            bullet.EnableBullet(true, dir, transform.position);
            bullets.Add(bullet);
        }

        // bullet.EnableBullet(true, dir, transform.position);
        // for (int i = bullets.Count - 1; i >= 0; i--)
        // {
        //     if (i < 0)
        //         continue;
        //     bullets[i].EnableBullet(false);
        //     bullets.RemoveAt(i);
        // }
        // bullet.ShakingBullet(5f, 1f);

    }

    void HandleMovePerformed(InputAction.CallbackContext ctx)
    {
        var vel = ctx.ReadValue<Vector2>().normalized * 5f;
        GetComponent<Rigidbody2D>().velocity = vel;
    }


    void HandleBulletHit(OnBulletHit e)
    {
        if (e.Target == gameObject)
        {
            //GameOver
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