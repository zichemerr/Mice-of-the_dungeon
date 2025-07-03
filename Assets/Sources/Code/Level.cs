using System;
using UnityEngine;

[Serializable]
public class Level
{
    [SerializeField] private LevelsEntity _levelsEntity;
    
    private int _maxLevels => _levelsEntity.LevelCount - 1;

    public int CurrentLevel { get; private set; }
    public LevelsEntity Data => _levelsEntity;
    
    public void NextLevel()
    {
        if (CurrentLevel == _maxLevels)
        {
            Debug.Log("IndexCurrentScene == _maxLevels game пройдена");
            return;
        }
        
        CurrentLevel++;
    }
}
