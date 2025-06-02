using UnityEngine;

public class AudioSorceContainer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public AudioSource AudioSource => _audioSource;
}
