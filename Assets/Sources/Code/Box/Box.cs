using System;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PointSpawner _pointSpawner;
    
    public void Init()
    {
        Disable();
        _pointSpawner.Entered += OnEntered;
    }
    
    private void OnDisable()
    {
        if (_pointSpawner == null)
            return;
        _pointSpawner.Entered -= OnEntered;
    }

    private void OnEntered(Vector2 arg1, int arg2, PointSpawner arg3)
    {
        Enable();
    }

    public void Enable()
    {
        _rigidbody.isKinematic = false;
        _spriteRenderer.color = Color.white;
    }

    public void Disable()
    {
        _rigidbody.isKinematic = true;
    }
}