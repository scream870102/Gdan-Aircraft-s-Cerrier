using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIconControl : MonoBehaviour
{
    public Player Player;
    public IconSpriteContainer IconSpriteContainer;
    public Image IconImage;
    private Dictionary<SpriteType, Sprite> iconDic = null;

    void Awake()
    {
        iconDic = IconSpriteContainer.ToDictionary();
        IconImage = GetComponent<Image>();
    
    }

    // Start is called before the first frame update
    void Start()
    {
        IconImage.sprite = iconDic[SpriteType.Default];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeIcon(ItemType type)
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
