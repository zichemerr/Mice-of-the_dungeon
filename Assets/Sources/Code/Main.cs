using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenuPrefab;
    [SerializeField] private Transform _screenParent;
    [SerializeField] private MainSettingsConfig _mainSettingsConfig;
    
    private Game _game;
    
    private void Start()
    {
        var mainMenu = Instantiate(_mainMenuPrefab, _screenParent);
        mainMenu.Init(this);
        
        _game = new Game(mainMenu, _mainSettingsConfig.LevelsConfig);
    }
    
    private void Update()
    {
        _game?.ThisUpdate();
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void StartGame()
    {
        _game.StartGame();
    }
}
