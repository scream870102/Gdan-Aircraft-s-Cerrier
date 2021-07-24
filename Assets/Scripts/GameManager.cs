using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scream.UniMO;
#if UNITY_EDITOR
using Scream.UniMO.Editor;
#endif
using Lean.Pool;

public class GameManager : MonoBehaviour
{
    [SerializeField] float itemSpawnOffset = 5f;
    [SerializeField] GameObject itemPrefab = null;
    [SerializeField] Vector2 planeSize = default;
    [SerializeField] int maxItemAmount;
#if UNITY_EDITOR
    [ReadOnly, SerializeField]
#endif
    int currentItemAmount;
    ScaledTimer timer = null;

    void Awake()
    {
        timer = new ScaledTimer(itemSpawnOffset, false);
    }

    void Update()
    {
        if (timer.IsFinished && maxItemAmount > currentItemAmount)
        {
            currentItemAmount++;
            var obj = LeanPool.Spawn(itemPrefab);
            var pos = Math.RandomVec2(planeSize);
            obj.transform.position = pos;
            var item = obj.GetComponent<Item>();
            item.InitItem();
            timer.Reset();
        }
    }


    void HandleItemGet(OnItemGet e)
    {
        currentItemAmount--;
        timer.Reset();
    }

    void OnEnable()
    {
        DomainEvents.Register<OnItemGet>(HandleItemGet);
    }

    void OnDisable()
    {
        DomainEvents.UnRegister<OnItemGet>(HandleItemGet);
    }
}
