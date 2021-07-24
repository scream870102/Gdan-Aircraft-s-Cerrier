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

    List<Bullet> bullets = null;
    Bullet currentControl = null;
    

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
            }
            var bul = bullets[i];
            bullets.RemoveAt(i);
            if(bul.IsEnable) bul.EnableBullet(false);
        }
    }

    void InitBullet()
    {
        if(bullets.Count == 0)
        {
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
        if(!reverseTimer.IsFinished || bullets[0] == null || bullets.Count < 1) return;

        if(currentControl == bullets[0])
        {
            //切換回自機
            bullets[0].EnableControll(false, player.PlayerInput);
            player.EnableControll(true, player.PlayerInput);
            currentControl = null;
        }
        else
        {
            //切到子彈
            if(currentControl != null) currentControl.EnableControll(false, player.PlayerInput);
            bullets[0].EnableControll(true, player.PlayerInput);
            player.EnableControll(false, player.PlayerInput);
            currentControl = bullets[0];   
        }        
        reverseTimer.Reset();
    }

    public void HandleBullet2Control(InputAction.CallbackContext ctx)
    {
        if(!reverseTimer.IsFinished || bullets.Count < 2 || bullets[1] == null) return;

        if(currentControl == bullets[1])
        {
            //切換回自機
            bullets[1].EnableControll(false, player.PlayerInput);
            player.EnableControll(true, player.PlayerInput);
            currentControl = null;
        }
        else
        {
            //切到子彈
            if(currentControl != null) currentControl.EnableControll(false, player.PlayerInput);
            bullets[1].EnableControll(true, player.PlayerInput);
            player.EnableControll(false, player.PlayerInput);
            currentControl = bullets[1];   
        }        
        reverseTimer.Reset();
    }

    public void HandleBullet3Control(InputAction.CallbackContext ctx)
    {
        if(!reverseTimer.IsFinished || bullets.Count < 3 || bullets[2] == null) return;

        if(currentControl == bullets[2])
        {
            //切換回自機
            bullets[2].EnableControll(false, player.PlayerInput);
            player.EnableControll(true, player.PlayerInput);
            currentControl = null;
        }
        else
        {
            //切到子彈
            if(currentControl != null) currentControl.EnableControll(false, player.PlayerInput);
            bullets[2].EnableControll(true, player.PlayerInput);
            player.EnableControll(false, player.PlayerInput);
            currentControl = bullets[2];   
        }        
        reverseTimer.Reset();
    }

    public void HandleBullet4Control(InputAction.CallbackContext ctx)
    {
        if(!reverseTimer.IsFinished || bullets.Count < 4 || bullets[3] == null ) return;

        if(currentControl == bullets[3])
        {
            //切換回自機
            bullets[3].EnableControll(false, player.PlayerInput);
            player.EnableControll(true, player.PlayerInput);
            currentControl = null;
        }
        else
        {
            //切到子彈
            if(currentControl != null) currentControl.EnableControll(false, player.PlayerInput);
            bullets[3].EnableControll(true, player.PlayerInput);
            player.EnableControll(false, player.PlayerInput);
            currentControl = bullets[3];   
        }        
        reverseTimer.Reset(); 
    }

#endregion

    public float GetReverseTimer() => reverseTimer.Remain;
    public Bullet GetBullet() => currentControl;
}
