using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(LevelsConfig), menuName = "Configs/" + nameof(LevelsConfig), order = 0)]
public class LevelsConfig : ScriptableObject
{
    [SerializeField] private List<Level> _level;

    public int LevelCount => _level.Count;
    
    public Level GetLevelPrefabByIndex(int levelNumber)
    {
        return _level[levelNumber];
    }
}

