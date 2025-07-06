using UnityEngine;
using UnityEngine.SceneManagement;

public interface IMain
{
    public void StartGame();
}

public class Main : MonoBehaviour, IMain
{
    [SerializeField] private ScreenSwitcher _screenSwitcher;
    [SerializeField] private MainSettingsConfig _mainSettingsConfig;
    
    private Game _game;
    
    private void Start()
    {
        Level.Factory levelFactory = new Level.Factory(_mainSettingsConfig.LevelsConfig);
        _game = new Game(levelFactory, _mainSettingsConfig.LevelsConfig, _screenSwitcher, this);
        
        var mainMenu = _screenSwitcher.ShowScreen<MenuScreen>();
        mainMenu.Init(this);
    }
    
    private void Update()
    {
        _game?.ThisUpdate();

#if (UNITY_EDITOR)
        if (Input.GetKeyDown(KeyCode.R))
        {
            _game.ClearSaves();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.G))
            _game.NextLevel();
#endif
    }

    public void StartGame()
    {
        _game.StartGame();
    }
}