using Sources.Code.Gameplay.Sounds;
using UnityEngine;

[System.Serializable]
public struct Sound
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private float _volume;
    
    public AudioClip AudioClip => _audioClip;
    public float Volume => _volume * AudioSystem.GlobalVolume;
}