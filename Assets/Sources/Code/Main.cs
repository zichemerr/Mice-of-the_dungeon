using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Main : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenuPrefab;
    [SerializeField] private Transform _screenParent;
    [SerializeField] private Level _level;

    private MainMenu _mainMenu;
    private LevelBuilder _levelBuilder;
    
    private void Start()
    {
        _mainMenu = Instantiate(_mainMenuPrefab, _screenParent);
        _mainMenu.Init(this);
        
        _levelBuilder = new LevelBuilder(_level);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            _levelBuilder.Clear();
            _level.NextLevel();
            _levelBuilder.Build();
        }
    }

    public void StartGame()
    {
        _mainMenu.Disable();
        _levelBuilder.Build();
    }
}

public static class G
{
    public static AudioSystem audio;
    public static Level level;
}