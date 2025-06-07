using System;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
     private PointSpawner _pointSpawner;
    
    public void Init(PointSpawner pointSpawner)
    {
        _pointSpawner = pointSpawner;
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

    public void SetPositionAndRotation()
    {
        transform.position = new Vector2(-5, -1);
        //transform.position = position;
        //transform.rotation = rotation;
    }
}