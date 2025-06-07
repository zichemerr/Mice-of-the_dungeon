using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private MouseSpawnerController _mouseSpawner;
    
    public void Init(MouseSpawnerController mouseSpawnerController)
    {
        _mouseSpawner = mouseSpawnerController;
    }

    public void SpawnBox(BoxObject boxData)
    {
        Box box = Instantiate(D.Prefabs.Box);

        if (boxData.SpawnerPointIsNull == false)
        {
            PointSpawnerObject spawnerPoint = boxData.SpawnerPoint;
            PointSpawner pointSpawner = _mouseSpawner.SpawnPointSpawner(spawnerPoint.Position, spawnerPoint.Rotation);
            pointSpawner.Init(spawnerPoint.SpawnCount);
            box.Init(pointSpawner);
        }
        
        box.transform.position = boxData.Position;
        box.transform.rotation = boxData.Rotation;
    }
}
