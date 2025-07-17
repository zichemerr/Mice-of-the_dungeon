using Sources.Code.Configs;
using Sources.Code.Gameplay.Box;
using Sources.Code.Gameplay.Door;
using Sources.Code.Gameplay.GameEvents;
using Sources.Code.Gameplay.MouseAltars;
using Sources.Code.Gameplay.PlayerSystem;
using Sources.Code.Gameplay.Spawner;
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
    
        public void Destroy()
        {
            Destroy(gameObject);
        }

        public class Factory
        {
            private LevelsConfig _levelsConfig;
        
            public Factory(LevelsConfig levelsConfig)
            {
                _levelsConfig = levelsConfig;
            }

            public Level CreateLevelByIndex(int index)
            {
                var levelPrefab = _levelsConfig.GetLevelPrefabByIndex(index);
                var levelInstance = Instantiate(levelPrefab);
            
                var mouseSpawner = levelInstance.MouseSpawner;
            
                var playerMovement = levelInstance.PlayerMovement;
                playerMovement.Init(mouseSpawner);
            
                mouseSpawner.Init(levelInstance.MouseParent);
                mouseSpawner.GetMouse(levelInstance.PlayerPosition);
            
                var playerInput = levelInstance.PlayerInput;
                playerInput.Init(playerMovement);
            
                var mouseAltar = levelInstance.MouseAltar;
                mouseAltar.Init(levelInstance.MaxMouseCount, playerInput);
            
                var door = levelInstance.Door;
                door.Init(mouseAltar);
            
                var boxesRoot = levelInstance.BoxesRoot;
                boxesRoot.Init();
            
                return levelInstance;
            }
        }
    }
}
