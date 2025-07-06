using UnityEngine;

public class Game
{
    private readonly IMain _main;
    private readonly Level.Factory _levelFactory;
    private readonly MouseSpawner _mouseSpawner;
    private readonly LevelsConfig _levelsConfig;
    private readonly ScreenSwitcher _screenSwitcher;
    private readonly PlayerProgress _playerProgress;
    
    private Level _levelInstance;
    
    public int CurrentLevelNumber
    {
        get => _playerProgress.LevelNumber;
        set => _playerProgress.LevelNumber = value;
    }
    
    public int MaxLevels => _levelsConfig.LevelCount;

    public Game(Level.Factory levelFactory, LevelsConfig levelsConfig, ScreenSwitcher screenSwitcher, IMain main)
    {
        _levelFactory = levelFactory;
        _playerProgress = GameSaverLoader.Instance.PlayerProgress;
        _levelsConfig = levelsConfig;
        _screenSwitcher = screenSwitcher;
        _main = main;
    }

    public void ThisUpdate()
    {
        if (_screenSwitcher.ScreenIsNull<GameScreen>() == false && Input.GetKeyDown(KeyCode.Escape))
        {
            ClearLevel();
            var menuScreen = _screenSwitcher.ShowScreen<MenuScreen>();
            menuScreen.Init(_main);
        }
    }

    public void StartGame()
    {
        int levelIndex = CurrentLevelNumber - 1;
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
        if (CurrentLevelNumber == MaxLevels)
        {
            Debug.Log("Game completed");
            return;
        }

        ClearLevel();
        CurrentLevelNumber++;
        StartGame();
    }

    public void ClearSaves()
    {
        CurrentLevelNumber = 1;
    }
    
    public void ClearLevel()
    {
        if (_levelInstance == null)
            return;
        
        _levelInstance.Destroy();
        _levelInstance = null;
    }
}
