using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder
{
    private Level _level;
    private LevelObject _levelObject;
    
    public LevelBuilder(Level level)
    {
        _level = level;
    }

    public void Build()
    {
        LevelObject prefab = _level.Data.GetLevel(_level.CurrentLevel);
        _levelObject = GameObject.Instantiate(prefab);
    }

    public void Clear()
    {
        if (_levelObject == null)
        {
            throw new System.NullReferenceException("Level object is null but you still try to clear it.");
        }
        
        _levelObject.Destroy();
        _levelObject = null;
    }
}