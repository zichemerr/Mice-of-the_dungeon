using UnityEngine;

[CreateAssetMenu(fileName = nameof(SoundsConfig), menuName = "Configs/" + nameof(SoundsConfig), order = 0)]
public class SoundsConfig : ScriptableObject
{
    [SerializeField] private AudioClip _defeat;
    
    public AudioClip Defeat => _defeat;
}
