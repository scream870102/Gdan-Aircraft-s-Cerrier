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