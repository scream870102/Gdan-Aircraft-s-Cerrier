using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scream.UniMO;

public class BGMPlayer : MonoBehaviour
{
    new AudioSource audio = null;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }

}
