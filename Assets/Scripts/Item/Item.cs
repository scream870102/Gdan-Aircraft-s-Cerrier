using UnityEngine;
using Scream.UniMO;
using Lean.Pool;

public class Item : MonoBehaviour
{
    ItemType type;
    public void InitItem()
    {
        type = (ItemType)Random.Range(0, System.Enum.GetNames(typeof(ItemType)).Length);
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