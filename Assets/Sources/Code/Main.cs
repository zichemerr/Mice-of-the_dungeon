using Sources.Code.Configs;
using Sources.Code.Gameplay;
using Sources.Code.Gameplay.Sounds;
using Sources.Code.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.Code
{
    public class Main : MonoBehaviour, IMain
    {
        [SerializeField] private ScreenSwitcher _screenSwitcher;
        [SerializeField] private AudioSystem _audioSystem;
        [SerializeField] private MainSettingsConfig _mainSettingsConfig;
    
        private Game _game;
    
        private void Start()
        {
            _audioSystem.Init(_mainSettingsConfig.SoundsConfig);
            Level.Factory levelFactory = new Level.Factory(_audioSystem, _mainSettingsConfig);
            _game = new Game(levelFactory, _mainSettingsConfig.LevelsConfig, _mainSettingsConfig.GameEventScreenConfig, _screenSwitcher, this, _audioSystem);
        
            var mainMenu = _screenSwitcher.ShowScreen<MenuScreen>();
            mainMenu.Init(this);
        }
    
        private void Update()
        {
            _game?.ThisUpdate();

#if (UNITY_EDITOR)
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
#endif
        }

        public void StartGame()
        {
            _game.StartGame();
        }
    }
}