using System.Collections.Generic;
using UnityEngine;

public class Game
{
    private Level _level;
    private LevelObject _levelObject;
    private MouseSpawnerController _mouseSpawner;
    private MainMenu _mainMenu;
    private Player _player;
    
    public Game(Level level, MouseSpawnerController mouseSpawner, MainMenu mainMenu, Player player)
    {
        _level = level;
        _mouseSpawner = mouseSpawner;
        _mainMenu = mainMenu;
        _player = player;
    }

    public void StartGame()
    {
        LevelObject prefab = _level.Data.GetLevel(_level.CurrentLevel);
        _levelObject = Object.Instantiate(prefab);

        _mouseSpawner.Spawn(_levelObject.PlayerPosition).Enable();
        _mainMenu.Disable();
    }

    public void Clear()
    {
        if (_levelObject == null)
        {
            throw new System.NullReferenceException("Level object is null but you still try to clear it.");
        }
        
        _levelObject.Destroy();
        _player.ClearAllMouses();
        _levelObject = null;
    }
}