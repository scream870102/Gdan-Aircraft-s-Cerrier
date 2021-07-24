using Scream.UniMO.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "SFXContainer", menuName = "ScriptableObjects/SFXContainer")]
class SFXContainer : Container<SFXType, AudioInfo> { }

[System.Serializable]
class AudioInfo
{
    public AudioClip Clip = null;
    public float Volume = 1f;
}