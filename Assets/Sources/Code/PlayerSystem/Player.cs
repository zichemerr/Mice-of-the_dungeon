using System.Collections.Generic;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerInput _playerInput;
        
    private MouseSpawner _mouseSpawner;
        
    public void Init(MouseSpawner mouseSpawner)
    {
        _mouseSpawner = mouseSpawner;
        _playerMovement.Init(_mouseSpawner);
        _playerInput.Init(_playerMovement);
    }
}