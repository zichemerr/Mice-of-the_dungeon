using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour, IMain
{
    [SerializeField] private ScreenSwitcher _screenSwitcher;
    [SerializeField] private MainSettingsConfig _mainSettingsConfig;

    private Game _game;

    private void Start()
    {
        _game = new Game(_mainSettingsConfig.LevelsConfig, _screenSwitcher, this);

        var mainMenu = _screenSwitcher.ShowScreen<MenuScreen>();
        mainMenu.Init(this);
    }

    private void Update()
    {
        _game?.ThisUpdate();

#if (UNITY_EDITOR)
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (Input.GetKeyDown(KeyCode.G))
            _game.NextLevel();
#endif
    }

    public void StartGame()
    {
        _game.StartGame();
    }

    [ContextMenu(nameof(ClearSave))]
    private void ClearSave()
    {
        _game.ClearSaves();
    }
}