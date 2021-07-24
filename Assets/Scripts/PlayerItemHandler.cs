using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.InputSystem;

public class PlayerItemHandler
{
    private Player player;
    
    public PlayerItemHandler(Player player)
    {
        this.player = player;
    }

    public void AutoUseDebuffItem(ItemType currentItem)
    {
        switch(currentItem)
        {
            case ItemType.Deform:
                SetDeform();
                player.CurrentItem = ItemType.Empty;
            break;

            case ItemType.Rever:
                SetReverse();
                player.CurrentItem = ItemType.Empty;
            break;

            default:
                break;
        }
    }
    
    public void OnItemPerformed(InputAction.CallbackContext ctx)
    {        
        switch(player.CurrentItem)
        {
            case ItemType.Multicon:
                if(player.PlayerFire.bullets.Count <= 0) 
                    break;
                foreach(var bul in player.PlayerFire.bullets)
                {
                    bul.EnableControll(true, player.PlayerInput);
                    player.EnableControll(false, player.PlayerInput);
                }
                player.CurrentItem = ItemType.Empty;
            break;
            
            case ItemType.Invi:
                SetPlayerInvi();
                player.CurrentItem = ItemType.Empty;
            break;

            case ItemType.Pendulum:
                if(player.PlayerFire.bullets.Count <= 0)
                    break;
                foreach(var bul in player.PlayerFire.bullets)
                {
                    bul.PendulumBullet(3f, 1f);
                }
                player.CurrentItem = ItemType.Empty;
            break;

            default:
                break;
        }
    }

    private async void SetPlayerInvi()
    {
        player.IsInvi = true;
        await UniTask.Delay( (int)(player.FireCd * 1000) );
        player.IsInvi = false;
    }

    private async void SetReverse()
    {
        player.PlayerMovement.ReverseControllDirection();
        foreach (var bul in player.PlayerFire.bullets)
        {
            bul.ReverseControllDirection();
        }
        await UniTask.Delay((int)(player.FireCd * 1000));
        player.PlayerMovement.ReverseControllDirection();
        foreach (var bul in player.PlayerFire.bullets)
        {
            bul.ReverseControllDirection();
        }
    }

    private async void SetDeform()
    {
        player.IsDeform = true;
        player.PlayerFire.currentControl?.BulletDeform(true);
        Debug.Log("a");
        await UniTask.Delay((int)(player.FireCd * 1000));
        player.IsDeform = false;
        player.PlayerFire.currentControl?.BulletDeform(false);
        Debug.Log("b");
    }
}   
