using UnityEngine;
using Scream.UniMO;

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
            DomainEvents.Raise(new OnItemGet(type));
        }
    }
}