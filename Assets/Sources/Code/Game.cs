using System.Collections.Generic;
using UnityEngine;

public class Game
{
    private Level _level;
    private MouseSpawner _mouseSpawner;
    private LevelsConfig _levelsConfig;
    private ScreenSwitcher _screenSwitcher;

    public int CurrentLevel { get; private set; } = 1;
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
        Level prefab = _levelsConfig.GetLevel(CurrentLevel - 1);
        _level = Object.Instantiate(prefab);
        
        _mouseSpawner = _level.MouseSpawner;
        var playerMovement = _level.PlayerMovement;
        var playerInput = _level.PlayerInput;
        
        playerMovement.Init(_mouseSpawner);
        playerMovement.MouseEnded += PlayerOnDied;
        playerInput.Init(playerMovement);
        
        _mouseSpawner.Init(_level.MouseParent);
        _mouseSpawner.GetMouse(_level.PlayerPosition);

        _screenSwitcher.ShowScreen<GameScreen>();
    }
    
    private void PlayerOnDied()
    {
        Debug.Log("Defeat");
    }
    
    public void NextLevel()
    {
        if (CurrentLevel == MaxLevels)
        {
            Debug.Log("Game completed");
            return;
        }

        ClearLevel();
        CurrentLevel++;
        StartGame();
    }
    
    public void ClearLevel()
    {
        if (_level == null)
            return;
        
        _level.Destroy();
        _level = null;
    }
}
