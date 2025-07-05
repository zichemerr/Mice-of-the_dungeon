using UnityEngine;
using System;
using System.Collections.Generic;

public class MouseSpawnerController : MonoBehaviour
{
    [SerializeField] private Mouse _mousePrefab;
    [SerializeField] private int _mouseCount;

    private List<PointSpawner> _pointsSpawner = new List<PointSpawner>();
    private MouseSpawner _spawner;
    private Transform _parent;
    
    public event Action<Mouse> Spawned;

    public void Init(Transform spawnParent)
    {
        _parent = spawnParent;
        _spawner = new MouseSpawner(_mousePrefab, _mouseCount);
        _spawner.Init(_parent);
    }

    private void OnDisable()
    {
        if (_pointsSpawner == null)
            return;
        
        foreach (var pointSpawner in _pointsSpawner)
            pointSpawner.Entered -= OnEntered;
    }

    private void OnEntered(Vector2 position, int spawnCount, PointSpawner pointSpawner)
    {
        Mouse[] mouses = _spawner.GetMouses(spawnCount);

        foreach (var mouse in mouses)
        {
            Spawn(mouse, position);
        }

        pointSpawner.Entered -= OnEntered;

        //Root.Effect.Play(position);
        //Root.Audio.Play(Root.Sound.Clap, 0.8f);
    }

    private Mouse Spawn(Mouse mouse, Vector2 position)
    {
        mouse.Init();
        mouse.SetPosition(position);
        Spawned?.Invoke(mouse);

        return mouse;
    }

    public Mouse Spawn(Vector2 position)
    {
        return Spawn(_spawner.GetMouse(), position);
    }

    public void AddMouse(Mouse mouse)
    {
        _spawner.AddMouse(mouse);
    }
}