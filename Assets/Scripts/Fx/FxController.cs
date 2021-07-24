using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Scream.UniMO;
using Lean.Pool;

public class FxController : TSingletonMonoBehavior<FxController>
{
    [SerializeField] ItemFxContainer itemContainer = null;
    [SerializeField] VFXContainer vfxContainer = null;
    [SerializeField] SFXContainer sfxContainer = null;
    Dictionary<ItemType, GameObject> itemFxDic = null;
    Dictionary<VFXType, GameObject> vfxDic = null;
    Dictionary<SFXType, AudioInfo> sfxDic = null;
    new AudioSource audio = null;
    protected override void Awake()
    {
        base.Awake();
        itemFxDic = itemContainer.ToDictionary();
        vfxDic = vfxContainer.ToDictionary();
        sfxDic = sfxContainer.ToDictionary();
        audio = GetComponent<AudioSource>();

    }

    void Update()
    {
#if UNITY_EDITOR
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            SpawnItemFx(ItemType.Multicon, transform.position);
        }
        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            SpawnVFX(VFXType.A, transform.position);
        }
        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            SpawnSFX(SFXType.C);
        }
#endif
    }

    public void SpawnItemFx(ItemType type, Vector2 position)
    {
        var obj = LeanPool.Spawn(itemFxDic[type]);
        obj.transform.position = position;
        obj.GetComponent<Animator>().WriteDefaultValues();
    }

    public void SpawnVFX(VFXType type, Vector2 position)
    {
        var obj = LeanPool.Spawn(vfxDic[type]);
        obj.transform.position = position;
        obj.GetComponent<Animator>().WriteDefaultValues();
    }

    public void SpawnSFX(SFXType type)
    {
        var info = sfxDic[type];
        Debug.Log(info.Clip.name);
        audio.volume = info.Volume;
        audio.PlayOneShot(info.Clip);
    }


}