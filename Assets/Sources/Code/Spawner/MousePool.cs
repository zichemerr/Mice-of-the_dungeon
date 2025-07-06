using System.Collections.Generic;
using UnityEngine;

public class MousePool
{
    private readonly Queue<Mouse> _pool;
    private readonly Transform _parent;
    private readonly Mouse _prefab;
    private readonly int _poolSize;

    public MousePool(Mouse prefab, Transform parent, int poolSize)
    {
        _pool = new Queue<Mouse>();
        _prefab = prefab;
        _parent = parent;
        _poolSize = poolSize;
    }

    public void Init()
    {
        for (int i = 0; i < _poolSize; i++)
            _pool.Enqueue(Spawn());
    }

    public void Dispose()
    {
        if (_pool == null)
            return;
        
        foreach (var mouse in _pool)
            mouse.Destroyed -= OnMouseDestroyed;
    }
    
    private Mouse Spawn()
    {
        Mouse mouse = Object.Instantiate(_prefab, _parent);
        mouse.Destroyed += OnMouseDestroyed;
        mouse.gameObject.SetActive(false);
        
        return mouse;
    }

    private void OnMouseDestroyed(Mouse mouse)
    {
        mouse.gameObject.SetActive(false);
        _pool.Enqueue(mouse);
    }

    public Mouse GetMouse()
    {
        if (_pool.Count > 0)
        {
            return _pool.Dequeue();;
        }
        
        Debug.LogWarning("There is not enough mice in the pool.");
        return Spawn();
    }
}