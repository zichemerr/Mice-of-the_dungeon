using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private ScreenSwitcher _screenSwitcher;
    [SerializeField] private MainSettingsConfig _mainSettingsConfig;
    
    private Game _game;
    
    private void Start()
    {
        Level.Factory levelFactory = new Level.Factory(_mainSettingsConfig.LevelsConfig);
        _game = new Game(levelFactory, _mainSettingsConfig.LevelsConfig, _screenSwitcher);
        
        var mainMenu = _screenSwitcher.ShowScreen<MenuScreen>();
        mainMenu.Init(this);
    }
    
    private void Update()
    {
        _game?.ThisUpdate();
        
        if (_screenSwitcher.ScreenIsNull<GameScreen>() == false && Input.GetKeyDown(KeyCode.Escape))
        {
            _game.ClearLevel();
            _screenSwitcher.ShowScreen<MenuScreen>();
        }

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