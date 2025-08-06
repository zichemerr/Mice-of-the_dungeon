using Sources.Code.Configs;
using Sources.Code.Gameplay.Box;
using Sources.Code.Gameplay.Door;
using Sources.Code.Gameplay.GameEvents;
using Sources.Code.Gameplay.Ghosts;
using Sources.Code.Gameplay.MouseAltars;
using Sources.Code.Gameplay.PlayerSystem;
using Sources.Code.Gameplay.Sounds;
using Sources.Code.Gameplay.Spawner;
using Sources.Code.Particles;
using UnityEngine;

namespace Sources.Code
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _playerPointPosition;
        [SerializeField] private Transform _mouseParent;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private MouseSpawner _mouseSpawner;
        [SerializeField] private Door _door;
        [SerializeField] private MouseAltar _mouseAltar;
        [SerializeField] private BoxesRoot _boxesRoot;
        [SerializeField] private GameEventScreen _gameEventScreen;
        [SerializeField] private Ghost _ghost;
        [SerializeField] private bool _ghostEnabled;
        [SerializeField] private Transform _particleParent;
        [SerializeField] private MouseDeath _mouseDeath;
        [SerializeField] private int _maxMouseCount;
    
        public Vector2 PlayerPosition => _playerPointPosition.position;
        public PlayerMovement PlayerMovement => _playerMovement;
        public PlayerInput PlayerInput => _playerInput;
        public MouseSpawner MouseSpawner => _mouseSpawner;
        public Transform MouseParent => _mouseParent;
        public Door Door => _door;
        public MouseAltar MouseAltar => _mouseAltar;
        public int MaxMouseCount => _maxMouseCount;
        public BoxesRoot BoxesRoot => _boxesRoot;
        public GameEventScreen GameEventScreen => _gameEventScreen;
        public Ghost Ghost => _ghost;
        public Transform ParticleParent => _particleParent;
        public MouseDeath MouseDeath => _mouseDeath;
        public bool GhostEnabled => _ghostEnabled;
    
        public void Destroy()
        {
            Destroy(gameObject);
        }

        public class Factory
        {
            private MainSettingsConfig _mainConfig;
            private AudioSystem _audioSystem;
        
            public Factory(AudioSystem audioSystem, MainSettingsConfig mainConfig)
            {
                _audioSystem = audioSystem;
                _mainConfig = mainConfig;
            }

            public Level CreateLevelByIndex(int index)
            {
                var levelPrefab = _mainConfig.LevelsConfig.GetLevelPrefabByIndex(index);
                var levelInstance = Instantiate(levelPrefab);
            
                var mouseSpawner = levelInstance.MouseSpawner;
            
                Particle particle = new Particle(_mainConfig.ParticleConfig, levelInstance.ParticleParent); 
                
                var mouseDeath = levelInstance.MouseDeath;
                mouseDeath.Init(_audioSystem);
                
                var playerMovement = levelInstance.PlayerMovement;
                playerMovement.Init(mouseSpawner);
            
                mouseSpawner.Init(levelInstance.MouseParent, particle, _audioSystem);
                mouseSpawner.GetMouse(levelInstance.PlayerPosition);
            
                var playerInput = levelInstance.PlayerInput;
                playerInput.Init(playerMovement);
            
                var mouseAltar = levelInstance.MouseAltar;
                mouseAltar.Init(levelInstance.MaxMouseCount, playerInput);
            
                var door = levelInstance.Door;
                door.Init(mouseAltar, _mainConfig.DoorConfig);
            
                var boxesRoot = levelInstance.BoxesRoot;
                boxesRoot.Init();

                if (levelInstance.GhostEnabled)
                {
                    var ghost = levelInstance.Ghost;
                    ghost.Init(_mainConfig.GhostConfig);
                }
                
                return levelInstance;
            }
        }
    }
}
