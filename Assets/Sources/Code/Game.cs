using System.Collections.Generic;
using UnityEngine;

public class Game
{
    private Level _level;
    private MouseSpawner _mouseSpawner;
    private Player _player;
    private LevelsConfig _levelsConfig;
    private ScreenSwitcher _screenSwitcher;
    
    public int CurrentLevel { get; private set; }
    public int MaxLevels => _levelsConfig.LevelCount;
    
    public Game(LevelsConfig levelsConfig, ScreenSwitcher screenSwitcher)
    {
        _levelsConfig = levelsConfig;
        _screenSwitcher = screenSwitcher;
    }
    
    public void ThisUpdate()
    {
        
    }
    
    public void StartGame()
    {
        Level prefab = _levelsConfig.GetLevel(CurrentLevel);
        _level = Object.Instantiate(prefab);

        _player = _level.Player;
        _mouseSpawner = _level.MouseSpawner;
        
        _player.Init(_mouseSpawner);
        _mouseSpawner.Init(_level.MouseParent);
        _mouseSpawner.GetMouse(_level.PlayerPosition);

        _screenSwitcher.ShowScreen<GameScreen>();
    }

    public void ClearLevel()
    {
        if (_level == null)
            return;
        
        _level.Destroy();
        _level = null;
    }
}
