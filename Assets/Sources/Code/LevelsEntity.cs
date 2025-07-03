using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsData", menuName = "Levels Data", order = 1)]
public class LevelsEntity : ScriptableObject
{
    [SerializeField] private List<LevelObject> _level;

    public int LevelCount => _level.Count;
    
    public LevelObject GetLevel(int levelNumber)
    {
        return _level[levelNumber];
    }
}

