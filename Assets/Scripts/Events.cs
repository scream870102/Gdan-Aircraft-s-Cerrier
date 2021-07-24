using Scream.UniMO;
using UnityEngine;

class OnBulletHit : IDomainEvent
{
    public GameObject Target { get; private set; }
    public OnBulletHit(GameObject gameObject)
    {
        Target = gameObject;
    }
}

class OnItemGet : IDomainEvent
{
    public ItemType Type { get; private set; }
    public OnItemGet(ItemType type)
    {
        Type = type;
    }
}