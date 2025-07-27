using UnityEngine;

[CreateAssetMenu(fileName = nameof(DoorConfig), menuName = "Configs/" + nameof(DoorConfig), order = 0)]
public class DoorConfig : ScriptableObject
{
    [SerializeField] private string _capretText;

    public string CapretText => _capretText;
}