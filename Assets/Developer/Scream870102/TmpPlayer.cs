using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using Scream.UniMO;
using Scream.UniMO.Editor;
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
        DomainEvents.Register<OnBulletHit>(HandleBulletHit);
    }


    void OnDisable()
    {
        input.GamePlay.Bullet1.performed -= HandleBtnConfirmed;
        DomainEvents.UnRegister<OnBulletHit>(HandleBulletHit);
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


    void HandleBulletHit(OnBulletHit e)
    {
        if(e.Target==gameObject){
            //GameOver
        }
    }

}