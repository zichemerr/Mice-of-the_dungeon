using UnityEngine;
using System;

public class MouseSpawnerController : MonoBehaviour
{
    [SerializeField] private PointSpawner[] _pointSpawner;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Mouse _mousePrefab;
    [SerializeField] private int _spawnCount = 1;

    private MouseSpawner _spawner;

    public Vector2 SpawnPoint => _spawnPoint.position;
    public event Action<Mouse> Spawned;

    public void Init()
    {
        _spawner = new MouseSpawner(_mousePrefab);

        for (int i = 0; i < _spawnCount; i++)
        {
            Spawn(_spawner.Spawn(), _spawnPoint.position);
        }

        foreach (var pointSpawner in _pointSpawner)
        {
            pointSpawner.Init();
            pointSpawner.Entered += OnEntered;
        }
    }

    private void OnDisable()
    {
        foreach (var pointSpawner in _pointSpawner)
            pointSpawner.Entered -= OnEntered;
    }

    private void OnEntered(Vector2 position, int spawnCount, PointSpawner pointSpawner)
    {
        Mouse[] mouses = _spawner.Spawn(spawnCount);

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
        return Spawn(_spawner.Spawn(), position);
    }
}