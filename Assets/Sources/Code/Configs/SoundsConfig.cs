using UnityEngine;

[CreateAssetMenu(fileName = nameof(SoundsConfig), menuName = "Configs/" + nameof(SoundsConfig), order = 0)]
public class SoundsConfig : ScriptableObject
{
    [SerializeField] private AudioClip _defeat;
    [SerializeField] private AudioClip _death;
    [SerializeField] private AudioClip _born;
    
    public AudioClip Defeat => _defeat;
    public AudioClip Death => _death;
    public AudioClip Born => _born;
}