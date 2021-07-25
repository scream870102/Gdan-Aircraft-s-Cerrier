using System.Collections.Generic;
using UnityEngine;
using Scream.UniMO;
using Lean.Pool;
using Cysharp.Threading.Tasks;

public class Item : MonoBehaviour
{
    ItemType type = default;
    [SerializeField] ItemContainer spriteContainer;
    [SerializeField] float lifeTime = 2f;
    SpriteRenderer sr = null;
    Dictionary<ItemType, Sprite> spriteDic;
    ScaledTimer timer = null;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        spriteDic = spriteContainer.ToDictionary();
        timer = new ScaledTimer(lifeTime);
    }

    public void InitItem()
    {
        type = (ItemType)Random.Range(1, System.Enum.GetNames(typeof(ItemType)).Length - 1);
        sr.sprite = spriteDic[type];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DomainEvents.Raise(new OnItemGet(type, other.gameObject));
            FxController.Instance.SpawnItemFx(type, other.transform.position);
            FxController.Instance.SpawnSFX(SFXType.ItemGet);
            LeanPool.Despawn(gameObject, Time.deltaTime);
        }
    }

    void Update()
    {
        if (timer.IsFinished)
        {
            DomainEvents.Raise(new OnItemGet(type, null));
            LeanPool.Despawn(gameObject, Time.deltaTime);
        }
    }


    void OnEnable()
    {
        timer.Reset();
    }

}