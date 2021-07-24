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
    private float fireCd;
    private int bulletAmount;
    private float radiusBetweenBullet;

    List<Bullet> bullets = null;
    Bullet currentControl = null;
    

    ScaledTimer timer;

    public PlayerFire(Player player, GameObject prefab, float fireCd, int bulletAmount, float radiusBetweenBullet)
    {
        this.player = player;
        this.prefab = prefab;
        this.fireCd = fireCd;
        this.bulletAmount = bulletAmount;
        this.radiusBetweenBullet = radiusBetweenBullet;

        bullets = new List<Bullet>();
        timer = new ScaledTimer(fireCd, false);
    }

    // Update is called once per frame
    public void UpdateBullet()
    {
        if(timer.IsFinished)
        {
            RemoveBullet();
            InitBullet();
            timer.Reset();
        }
    }

    void RemoveBullet()
    {
        for(int i = bullets.Count - 1; i >= 0; i--)
        {
            Debug.Log(i);
            if(bullets[i].IsUnderControll)
            {
                bullets[i].EnableControll(false, player.PlayerInput);
                player.EnableControll(true, player.PlayerInput);
            }
            var bul = bullets[i];
            bullets.RemoveAt(i);
            LeanPool.Despawn(bul.gameObject);
        }
    }

    void InitBullet()
    {
        if(bullets.Count == 0)
        {
            Vector3 startPoint = Quaternion.Euler(0, 0, bulletAmount * radiusBetweenBullet / 2) * player.transform.right;
            Debug.Log(startPoint);
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

    public void HandleBullet1Control(InputAction.CallbackContext ctx)
    {
        if(bullets[0] == null || bullets.Count < 1) return;

        if(currentControl != null) currentControl.EnableControll(false, player.PlayerInput);
        bullets[0].EnableControll(true, player.PlayerInput);
        player.EnableControll(false, player.PlayerInput);
        currentControl = bullets[0];
    }

    public void HandleBullet2Control(InputAction.CallbackContext ctx)
    {
        if(bullets[1] == null || bullets.Count < 2) return;

        if(currentControl != null) currentControl.EnableControll(false, player.PlayerInput);
        bullets[1].EnableControll(true, player.PlayerInput);
        player.EnableControll(false, player.PlayerInput);
        currentControl = bullets[1];
    }

    public void HandleBullet3Control(InputAction.CallbackContext ctx)
    {
        if(bullets[2] == null || bullets.Count < 3) return;

        if(currentControl != null) currentControl.EnableControll(false, player.PlayerInput);
        bullets[2].EnableControll(true, player.PlayerInput);
        player.EnableControll(false, player.PlayerInput);
        currentControl = bullets[2];
    }

    public void HandleBullet4Control(InputAction.CallbackContext ctx)
    {
        if(bullets.Count < 4 || bullets[3] == null ) return;

        if(currentControl != null) currentControl.EnableControll(false, player.PlayerInput);
        bullets[3].EnableControll(true, player.PlayerInput);
        player.EnableControll(false, player.PlayerInput);
        currentControl = bullets[3];        
    }
}
