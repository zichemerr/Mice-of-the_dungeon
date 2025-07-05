using UnityEngine;
using System;
using System.Collections.Generic;

public class MouseSpawner : MonoBehaviour
{
    [SerializeField] private List<PointSpawner> _pointsSpawner;
    [SerializeField] private Mouse _mousePrefab;
    [SerializeField] private int _poolSize;
    
    private MousePool _mousePool;
    
    public event Action<Mouse> Spawned;

    public void Init(Transform spawnParent)
    {
        _mousePool = new MousePool(_mousePrefab, spawnParent, _poolSize);
        _mousePool.Init();
    }
    
    private void OnEnable()
    {
        foreach (var pointSpawner in _pointsSpawner)
            pointSpawner.Entered += OnEntered;
    }

    private void OnDisable()
    {
        _mousePool.Dispose();
        
        if (_pointsSpawner == null)
            return;
        
        foreach (var pointSpawner in _pointsSpawner)
            pointSpawner.Entered -= OnEntered;
    }

    private void OnEntered(Vector2 position, int spawnCount, PointSpawner pointSpawner)
    {
        GetMouses(position, spawnCount);
        pointSpawner.Entered -= OnEntered;

        //Sttrox: я избавился от статики
        //Root.Effect.Play(position);
        //Root.Audio.Play(Root.Sound.Clap, 0.8f);
    }

    public Mouse[] GetMouses(Vector2 position, int count)
    {
        Mouse[] mouses = new Mouse[count];

        for (int i = 0; i < mouses.Length; i++)
            mouses[i] = GetMouse(position);
        
        return mouses;
    }
    
    public Mouse GetMouse(Vector2 position)
    {
        var mouse = _mousePool.GetMouse();
        
        mouse.gameObject.SetActive(true);
        mouse.Init();
        mouse.SetPosition(position);
        Spawned?.Invoke(mouse);

        return mouse;
    }
}