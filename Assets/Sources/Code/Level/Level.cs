using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform _playerPointPosition;
    [SerializeField] private Transform _mouseParent;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private MouseSpawner _mouseSpawner;
    
    public Vector2 PlayerPosition => _playerPointPosition.position;
    public PlayerMovement PlayerMovement => _playerMovement;
    public PlayerInput PlayerInput => _playerInput;
    public MouseSpawner MouseSpawner => _mouseSpawner;
    public Transform MouseParent => _mouseParent;
    
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
            
            return levelInstance;
        }
    }
}
