using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIconControl : MonoBehaviour
{
    public IconSpriteContainer IconSpriteContainer;
    public Image IconImage;
    private Dictionary<SpriteType, Sprite> iconDic = null;

    void Awake()
    {
        iconDic = IconSpriteContainer.ToDictionary();
        IconImage = GetComponent<Image>();
    
    }

    public void ChangeIcon(ItemType type)
    {
        if(type == ItemType.Empty)
        {
            IconImage.sprite = iconDic[SpriteType.Default];
        }
        else
        {
            IconImage.sprite = iconDic[SpriteType.GetItem];
        }
    }
}
