using Scream.UniMO;
using UnityEngine;

class OnBulletHit : IDomainEvent
{
    public GameObject Target { get; private set; }
    public OnBulletHit(GameObject gameObject) => Target = gameObject;
}

class OnItemGet : IDomainEvent
{
    public ItemType Type { get; private set; }
    public GameObject Getter { get; private set; }
    public OnItemGet(ItemType type, GameObject getter)
    {
        Type = type;
        Getter = getter;
    }
}


class OnPlayerDead : IDomainEvent
{
    public Player Player { get; private set; }
    public OnPlayerDead(Player player) => Player = player;
}