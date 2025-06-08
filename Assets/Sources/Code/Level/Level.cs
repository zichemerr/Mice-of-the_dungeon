using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private BoxObject[] _boxes;
    [SerializeField] private PointSpawnerObject[] _pointsSpawner;
    [SerializeField] private WallObject[] _walls;
    [SerializeField] private BuildObject _door;
    [SerializeField] private BuildObject _importer;
    [SerializeField] private int _importerCount;
    
    public int BoxObjectCount => _boxes.Length;
    public int PointSpawnerObjectCount => _pointsSpawner.Length;
    public int WallObjectCount => _walls.Length;
    public BuildObject Door => _door;
    public BuildObject Importer => _importer;
    public int ImporterCount => _importerCount;

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

        _door.Init();
        _importer.Init();
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
        if (Transform == null) 
            return;
        Width = _spriteRenderer.size.x;
        Height = _spriteRenderer.size.y;
    }
}

[Serializable]
public class BoxObject : BuildObject
{
    [field: SerializeField] public PointSpawnerObject SpawnerPoint { get; private set; }
    [field: SerializeField] public bool SpawnerPointIsNull { get; private set; } = true;

    public override void Init()
    {
        base.Init();
        if (Transform == null) 
            return;
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
    [field: SerializeField] public Transform Transform { get; private set; }
    [field: SerializeField] public Vector2 Position { get; private set; }
    [field: SerializeField] public Quaternion Rotation { get; private set; }

    public virtual void Init()
    {
        if (Transform == null)
            return;

        Position = Transform.position;
        Rotation = Transform.rotation;
    }
}