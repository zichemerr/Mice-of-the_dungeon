using System;
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
        private readonly LevelsConfig _levelsConfig;

        public Factory(LevelsConfig levelsConfig)
        {
            _levelsConfig = levelsConfig;
        }

        public Level CreateLevelByIndex(int levelIndex )
        {
            Level levelPrefab = _levelsConfig.GetLevelPrefabByIndex(levelIndex);
            var levelInstance  = GameObject.Instantiate(levelPrefab);
            
            var mouseSpawner = levelInstance.MouseSpawner;
            mouseSpawner.Init(levelInstance.MouseParent);
            mouseSpawner.GetMouse(levelInstance.PlayerPosition);
            
            var playerMovement = levelInstance.PlayerMovement;
            playerMovement.Init(mouseSpawner);
            
            var playerInput = levelInstance.PlayerInput;
            playerInput.Init(playerMovement);
            
            return levelInstance;
        }
    }
}
