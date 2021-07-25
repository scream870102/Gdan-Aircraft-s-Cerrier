using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
using Scream.UniMO;
using Scream.UniMO.Editor;
using UnityEngine.InputSystem;

public class PlayerFire 
{
    private Player player;
    private GameObject prefab = null;
    private int bulletAmount;
    private float radiusBetweenBullet;
    private bool isLeft;

    public List<Bullet> bullets = null;
    public Bullet currentControl = null;
    public bool BulletLeft = false;
    

    ScaledTimer fireTimer;
    ScaledTimer reverseTimer;

    public PlayerFire(Player player, GameObject prefab, float fireCd, int bulletAmount, float radiusBetweenBullet, float reverseCd, bool isLeft)
    {
        this.player = player;
        this.prefab = prefab;
        this.bulletAmount = bulletAmount;
        this.radiusBetweenBullet = radiusBetweenBullet;
        this.isLeft = isLeft;

        bullets = new List<Bullet>();
        fireTimer = new ScaledTimer(fireCd, false);
        reverseTimer = new ScaledTimer(reverseCd, false);
    }

    public void UpdateBullet()
    {
        
        if(fireTimer.IsFinished)
        {
            RemoveBullet();
            InitBullet();
            player.PlayerAnimator.SetTrigger("AttackTrigger");
            FxController.Instance.SpawnSFX(SFXType.Attack);
            fireTimer.Reset();
        }
    }

    void RemoveBullet()
    {
        for(int i = bullets.Count - 1; i >= 0; i--)
        {            
            if(bullets[i].IsUnderControll)
            {
                bullets[i].EnableControll(false, player.PlayerInput);
                player.EnableControll(true, player.PlayerInput);
                currentControl = null;
            }
            var bul = bullets[i];
            bullets.RemoveAt(i);
            if(bul.IsEnable) bul.EnableBullet(false);
        }
        BulletLeft = false;
    }

    void InitBullet()
    {
        if(bullets.Count == 0)
        {
            BulletLeft = true;
            Vector3 startPoint = Quaternion.Euler(0, 0, bulletAmount * radiusBetweenBullet / 2) * (isLeft ? -player.transform.right : player.transform.right);
            
            for(int i = 0; i < bulletAmount; i++)
            {
                var obj = LeanPool.Spawn(prefab);
                var bullet = obj.GetComponent<Bullet>();
                var dir = Quaternion.Euler(0, 0, -(90 / (bulletAmount-1)) * i) * startPoint;
                bullet.EnableBullet(true, player.gameObject, dir, player.transform.position);
                bullets.Add(bullet);
            }
        }
    }

#region HandleBulletControl

    public void HandleBullet1Control(InputAction.CallbackContext ctx)
    {
        HandleBulletControl(0);
    }

    public void HandleBullet2Control(InputAction.CallbackContext ctx)
    {
        HandleBulletControl(1);
    }

    public void HandleBullet3Control(InputAction.CallbackContext ctx)
    {
        HandleBulletControl(2);
    }

    public void HandleBullet4Control(InputAction.CallbackContext ctx)
    {
        HandleBulletControl(3);
    }

#endregion

    public void HandleBulletControl(int index)
    {
        if(!reverseTimer.IsFinished || bullets.Count < index+1 || bullets[index] == null) return;

        if(currentControl == bullets[index])
        {
            //切換回自機
            if(player.IsDeform) bullets[index].BulletDeform(false);

            bullets[index].EnableControll(false, player.PlayerInput);
            player.EnableControll(true, player.PlayerInput);
            currentControl = null;
        }
        else
        {
            //切到子彈
            if(player.IsDeform) bullets[index].BulletDeform(true);

            if(currentControl != null) 
            {
                currentControl.BulletDeform(false);
                currentControl.EnableControll(false, player.PlayerInput);
            }
            bullets[index].EnableControll(true, player.PlayerInput);
            player.EnableControll(false, player.PlayerInput);
            currentControl = bullets[index];
        }        
        reverseTimer.Reset();
    }

    public float GetReverseTimer() => reverseTimer.Remain;
    public Bullet GetBullet() => currentControl;

}
