using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private BoxObject[] _boxes;
    
    public int BoxObjectCount => _boxes.Length;

    public BoxObject GetBoxObject(int index) => _boxes[index];

    [ContextMenu("LoadData")]
    private void LoadData()
    {
        foreach (var box in _boxes)
            box.Init();
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