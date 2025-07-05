using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = nameof(LevelsConfig), menuName = "Configs/" + nameof(LevelsConfig), order = 0)]
public class LevelsConfig : ScriptableObject
{
    [FormerlySerializedAs("_level")] [SerializeField] private List<Level> _levels;

    public int LevelCount => _levels.Count;
    
    public Level GetLevelPrefabByIndex(int levelIndex)
    {
        return _levels[levelIndex];
    }
}

