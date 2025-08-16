using UnityEngine;

[CreateAssetMenu(fileName = nameof(SoundsConfig), menuName = "Configs/" + nameof(SoundsConfig), order = 0)]
public class SoundsConfig : ScriptableObject
{
    [SerializeField] private Sound _defeat;
    [SerializeField] private Sound _death;
    [SerializeField] private Sound _born;
    [SerializeField] private Sound _door;
    [SerializeField] private Sound _enter;
    [SerializeField] private Sound _scaryPiano;
    [SerializeField] private Sound _click;
    [SerializeField] private Sound _write;
    [SerializeField] private Sound _boxKnock;
    [SerializeField] private Sound _win;
    [SerializeField] private Sound _scream;
    
    public Sound Death => _death;
    public Sound Born => _born;
    public Sound Door => _door;
    public Sound Enter => _enter;
    public Sound ScaryPiano => _scaryPiano;
    public Sound Click => _click;
    public Sound Write => _write;
    public Sound BoxKnock => _boxKnock;
    public Sound Win => _win;
    public Sound Scream => _scream;
    public Sound Defeat => _defeat;
}