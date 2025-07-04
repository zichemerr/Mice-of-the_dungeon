using System;
using UnityEngine;

public class LevelObject : MonoBehaviour
{
    [SerializeField] private Transform _playerPointPosition;
    
    public Vector2 PlayerPosition => _playerPointPosition.position;
    
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
