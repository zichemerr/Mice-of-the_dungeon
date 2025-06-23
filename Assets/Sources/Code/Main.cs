using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private IntroController _introController;
    [SerializeField] private MouseSpawnerController _mouseSpawnerController;
    [SerializeField] private BoxController _boxController;
    [SerializeField] private GhostView _ghostView;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private LevelBuilder _levelBuilder;
    
    private AudioSystem _audioSystem;
    private Level _level;
    
    private void Start()
    {
        CMS.Init();
        _audioSystem = new AudioSystem();
        G.audio = _audioSystem;
        _player.Init();
        _boxController.Init(_mouseSpawnerController);
        _mouseSpawnerController.Init();
        _levelBuilder.Init(_ghostView, _mouseSpawnerController, _boxController, _playerInput, _player);
        _level = new Level(_levelBuilder);
        G.level = _level;
        _level.Init();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

public static class G
{
    public static AudioSystem audio;
    public static Level level;
}