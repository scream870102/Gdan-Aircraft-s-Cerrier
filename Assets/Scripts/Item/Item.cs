using System.Collections.Generic;
using UnityEngine;
using Scream.UniMO;
using Lean.Pool;

public class Item : MonoBehaviour
{
    ItemType type = default;
    [SerializeField] ItemContainer spriteContainer;
    SpriteRenderer sr = null;
    Dictionary<ItemType, Sprite> spriteDic;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        spriteDic = spriteContainer.ToDictionary();
    }

    public void InitItem()
    {
        type = (ItemType)Random.Range(1, System.Enum.GetNames(typeof(ItemType)).Length-1);
        sr.sprite = spriteDic[type];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DomainEvents.Raise(new OnItemGet(type, other.gameObject));
            LeanPool.Despawn(gameObject, Time.deltaTime);
        }
    }
}