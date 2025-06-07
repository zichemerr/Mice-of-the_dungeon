using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private BoxObject[] _boxes;
    [SerializeField] private PointSpawnerObject[] _pointsSpawner;
    [SerializeField] private WallObject[] _walls;
    
    public int BoxObjectCount => _boxes.Length;
    public int PointSpawnerObjectCount => _pointsSpawner.Length;
    public int WallObjectCount => _walls.Length;

    public BoxObject GetBoxObject(int index) => _boxes[index];
    public PointSpawnerObject GetPointSpawnerObject(int index) => _pointsSpawner[index];
    public WallObject GetWallObject(int index) => _walls[index];

    [ContextMenu("LoadData")]
    private void LoadData()
    {
        foreach (var box in _boxes)
            box.Init();

        foreach (var point in _pointsSpawner)
            point.Init();

        foreach (var wall in _walls)
            wall.Init();
    }
}

[Serializable]
public class WallObject : BuildObject
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [field: SerializeField] public float Width { get; private set; }
    [field: SerializeField] public float Height { get; private set; }

    public override void Init()
    {
        base.Init();
        Width = _spriteRenderer.size.x;
        Height = _spriteRenderer.size.y;
    }
}

[Serializable]
public class BoxObject : BuildObject
{
    [field: SerializeField] public PointSpawnerObject SpawnerPoint { get; private set; }
    [field: SerializeField] public bool SpawnerPointIsNull { get; private set; }

    public override void Init()
    {
        base.Init();

        if (SpawnerPointIsNull == false)
            SpawnerPoint.Init();
    }
}

[Serializable]
public class PointSpawnerObject : BuildObject
{
    [field: SerializeField] public int SpawnCount { get; private set; }
}

[Serializable]
public class BuildObject
{
    [SerializeField] private Transform _transform;
    [field: SerializeField] public Vector2 Position { get; private set; }
    [field: SerializeField] public Quaternion Rotation { get; private set; }
    
    public virtual void Init()
    {
        Position = _transform.position;
        Rotation = _transform.rotation;
    }
}