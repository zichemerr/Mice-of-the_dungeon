using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(MainSettingsConfig), menuName = "Configs/" + nameof(MainSettingsConfig), order = 0)]
public class MainSettingsConfig : ScriptableObject
{
    [field: SerializeField] public LevelsConfig LevelsConfig { get; private set;}
}