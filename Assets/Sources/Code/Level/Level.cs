using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform _playerPointPosition;
    [SerializeField] private Transform _mouseParent;
    [SerializeField] private Player _player;
    [SerializeField] private MouseSpawnerController _mouseSpawner;
    
    public Vector2 PlayerPosition => _playerPointPosition.position;
    public Player Player => _player;
    public MouseSpawnerController MouseSpawner => _mouseSpawner;
    public Transform MouseParent => _mouseParent;
    
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
