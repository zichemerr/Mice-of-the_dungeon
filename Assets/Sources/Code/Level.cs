using UnityEngine;

public class Level
{
    private LevelBuilder _levelBuilder;
    private int _maxLevels;
    
    public int LevelNumber { get; private set; }

    public Level(LevelBuilder levelBuilder)
    {
        _maxLevels = CMS.Get<LevelsEntity>().Get<TagLevels>().Levels.Count;
        _levelBuilder = levelBuilder;
    }

    public void Init()
    {
        _levelBuilder.BuildLevel(0);
    }

    public void NextLevel()
    {
        if (LevelNumber == _maxLevels - 1)
        {
            Debug.Log("IndexCurrentScene == _maxLevels game пройдена");
            return;
        }
        
        LevelNumber++;
        _levelBuilder.ClearLevel();
        _levelBuilder.BuildLevel(LevelNumber);
    }
}