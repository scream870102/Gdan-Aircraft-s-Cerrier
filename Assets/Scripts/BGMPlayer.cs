using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scream.UniMO;

public class BGMPlayer : TSingletonMonoBehavior<BGMPlayer>
{
    new AudioSource audio = null;
    // Start is called before the first frame update
    protected override void Awake()
    {
        if (BGMPlayer.Instance != this) DestroyImmediate(gameObject);
        base.Awake();
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();

    }

}
