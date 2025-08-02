using Cysharp.Threading.Tasks;
using Sources.Code.Configs;
using Sources.Code.Gameplay.GameEvents;
using Sources.Code.Gameplay.GameSaves;
using Sources.Code.Gameplay.PlayerSystem;
using Sources.Code.Gameplay.Sounds;
using Sources.Code.Gameplay.Spawner;
using Sources.Code.UI;
using UnityEngine;

namespace Sources.Code.Gameplay
{
    public class Game
    {
        private readonly IMain _main;
        private readonly Level.Factory _levelFactory;
        private readonly MouseSpawner _mouseSpawner;
        private readonly LevelsConfig _levelsConfig;
        private readonly ScreenSwitcher _screenSwitcher;
        private readonly PlayerProgress _playerProgress;
        private readonly GameEventScreenConfig _gameEventScreenConfig;
        private readonly AudioSystem _audioSystem;
    
        private Level _levelInstance;
        private GameEventScreen _gameEventScreen;
        private PlayerInput _playerInput;
    
        public int CurrentLevelNumber
        {
            get => _playerProgress.LevelNumber;
            set => _playerProgress.LevelNumber = value;
        }
    
        public int MaxLevels => _levelsConfig.LevelCount;

        public Game(Level.Factory levelFactory, LevelsConfig levelsConfig, GameEventScreenConfig gameEventScreenConfig, ScreenSwitcher screenSwitcher, IMain main, AudioSystem audioSystem)
        {
            _levelFactory = levelFactory;
            _playerProgress = GameSaverLoader.Instance.PlayerProgress;
            _levelsConfig = levelsConfig;
            _screenSwitcher = screenSwitcher;
            _main = main;
            _gameEventScreenConfig = gameEventScreenConfig;
            _audioSystem = audioSystem;
        }

        public void ThisUpdate()
        {
            if (_screenSwitcher.ScreenIsNull<GameScreen>() == false && Input.GetKeyDown(KeyCode.Escape))
            {
                ClearLevel();
                var menuScreen = _screenSwitcher.ShowScreen<MenuScreen>();
                menuScreen.Init(_main);
            }
        
#if (UNITY_EDITOR)
            if (Input.GetKeyDown(KeyCode.F))
                ClearSaves();

            if (Input.GetKeyDown(KeyCode.G))
                OnNextLevel();
#endif
        }
    
        public void StartGame()
        {
            int levelIndex = CurrentLevelNumber - 1;
            _levelInstance = _levelFactory.CreateLevelByIndex(levelIndex);

            _playerInput = _levelInstance.PlayerInput;
            _gameEventScreen = _levelInstance.GameEventScreen;
            _gameEventScreen.Init(_gameEventScreenConfig);
            
            var playerMovement = _levelInstance.PlayerMovement;
            var door = _levelInstance.Door;
        
            playerMovement.MouseEnded += PlayerOnDied;
            door.Entered += OnNextLevel;
            
            _screenSwitcher.ShowScreen<GameScreen>().Init();
        }
    
        private void PlayerOnDied()
        {
            _playerInput.Disable();
            DefeatLevel().Forget();
            _audioSystem.PlaySound(_audioSystem.Sounds.Defeat);
        }

        private async UniTaskVoid DefeatLevel()
        {
            await _gameEventScreen.ShowDefeat();
            await UniTask.WaitForSeconds(1);
            
            RestartLevel();
        }
    
        private void ClearLevel()
        {
            if (_levelInstance == null)
                return;
        
            _levelInstance.Destroy();
            _levelInstance = null;
        }
    
        private void OnNextLevel()
        {
            if (CurrentLevelNumber == MaxLevels)
            {
                _playerInput.Disable();
                _gameEventScreen.ShowVictory();
                return;
            }
            
            CurrentLevelNumber++;
            RestartLevel();
        }

        private void RestartLevel()
        {
            ClearLevel();
            StartGame();
        }
    
        private void ClearSaves()
        {
            CurrentLevelNumber = 1;
        }
    }
}