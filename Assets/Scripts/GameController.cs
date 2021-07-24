using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using Scream.UniMO;

#if UNITY_EDITOR
using Scream.UniMO.Editor;
#endif
using Lean.Pool;

public class GameController : MonoBehaviour
{
    [SerializeField] float itemSpawnOffset = 5f;
    [SerializeField] GameObject itemPrefab = null;
    [SerializeField] Vector2 planeSize = default;
    [SerializeField] int maxItemAmount;
    HashSet<Player> players = null;
#if UNITY_EDITOR
    [ReadOnly, SerializeField]
#endif
    int currentItemAmount;
    ScaledTimer timer = null;


    void GameEnd(Player winner)
    {
        //載入結算畫面
        FlowController.Instance.LoadScene(SceneIndex.Result, new ResultData(winner.name));
    }

    void Awake()
    {
        timer = new ScaledTimer(itemSpawnOffset, false);
        players = new HashSet<Player>();
        var playerObjs = FindObjectsOfType<Player>();
        foreach (var p in playerObjs)
        {
            players.Add(p);
        }
    }

    void Update()
    {
        if (timer.IsFinished && maxItemAmount > currentItemAmount)
        {
            currentItemAmount++;
            var obj = LeanPool.Spawn(itemPrefab);
            var x = Random.Range(-planeSize.x, planeSize.x);
            var y = Random.Range(-planeSize.y, planeSize.y);
            var pos = new Vector2(x,y);
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

    void HandlePlayerDead(OnPlayerDead e)
    {
        if (players.Contains(e.Player))
        {
            players.Remove(e.Player);
        }
        if (players.Count == 1)
        {
            Debug.Log(players.First().name);
            GameEnd(players.First());
        }
    }

    void OnEnable()
    {
        DomainEvents.Register<OnItemGet>(HandleItemGet);
        DomainEvents.Register<OnPlayerDead>(HandlePlayerDead);
    }

    void OnDisable()
    {
        DomainEvents.UnRegister<OnItemGet>(HandleItemGet);
        DomainEvents.UnRegister<OnPlayerDead>(HandlePlayerDead);
    }
}
