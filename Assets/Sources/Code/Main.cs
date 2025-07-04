using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenuPrefab;
    [SerializeField] private Transform _screenParent;
    [SerializeField] private MouseSpawnerController _mouseSpawner;
    [SerializeField] private Player _player;
    [SerializeField] private Level _level;
    
    private Game _game;
    
    private void Start()
    {
        var mainMenu = Instantiate(_mainMenuPrefab, _screenParent);
        mainMenu.Init(this);
        
        _player.Init(_mouseSpawner);
        _mouseSpawner.Init();
        
        _game = new Game(_level, _mouseSpawner, mainMenu, _player);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            _game.Clear();
            _level.NextLevel();
            _game.StartGame();
        }
    }

    public void StartGame()
    {
        _game.StartGame();
    }
}

public static class G
{
    public static AudioSystem audio;
    public static Level level;
}