using System.Collections.Generic;
using UnityEngine;

public class Game
{
    private Level _level;
    private MouseSpawnerController _mouseSpawner;
    private MainMenu _mainMenu;
    private Player _player;
    private LevelsConfig _levelsConfig;
    private int _currentLevel;
    
    public Game(MainMenu mainMenu, LevelsConfig levelsConfig)
    {
        _mainMenu = mainMenu;
        _levelsConfig = levelsConfig;
    }
    
    public void ThisUpdate()
    {
        
    }
    
    public void StartGame()
    {
        Level prefab = _levelsConfig.GetLevel(_currentLevel);
        _level = Object.Instantiate(prefab);

        _player = _level.Player;
        _mouseSpawner = _level.MouseSpawner;
        
        _player.Init(_mouseSpawner);
        _mouseSpawner.Init();
        _mouseSpawner.Spawn(_level.PlayerPosition);
        
        _mainMenu.Disable();
    }

    public void NextLevel()
    {
        _currentLevel++;
    }

    public void Clear()
    {
        if (_level == null)
        {
            throw new System.NullReferenceException("Level object is null but you still try to clear it.");
        }
        
        _level.Destroy();
        _player.ClearMouse();
        _level = null;
    }
}