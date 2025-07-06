using UnityEngine;

public class Game
{
    private readonly Level.Factory _levelFactory;
    private readonly MouseSpawner _mouseSpawner;
    private readonly LevelsConfig _levelsConfig;
    private readonly ScreenSwitcher _screenSwitcher;
    private readonly SettingsProgress _settings;
    
    private Level _levelInstance;

    public int CurrentLevel => _settings.Level;
    public int MaxLevels => _levelsConfig.LevelCount;

    public Game(Level.Factory levelFactory, LevelsConfig levelsConfig, ScreenSwitcher screenSwitcher)
    {
        _levelFactory = levelFactory;
        _settings = GameSaverLoader.Instance.SettingsProgress;
        _levelsConfig = levelsConfig;
        _screenSwitcher = screenSwitcher;
    }

    public void ThisUpdate()
    {
        
    }

    public void StartGame()
    {
        int levelIndex = CurrentLevel - 1;
        _levelInstance = _levelFactory.CreateLevelByIndex(levelIndex);

        var playerMovement = _levelInstance.PlayerMovement;
        playerMovement.MouseEnded += PlayerOnDied;
        
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
        _settings.Level++;
        StartGame();
    }

    public void ClearSaves()
    {
        _settings.Level = 1;
    }
    
    public void ClearLevel()
    {
        if (_levelInstance == null)
            return;
        
        _levelInstance.Destroy();
        _levelInstance = null;
    }
}
