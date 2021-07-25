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
        // base.Awake();
        if (Instance == null) Instance = this ;
        if (Instance == this) DontDestroyOnLoad(this);
        else DestroyImmediate(gameObject);
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();

    }

}
