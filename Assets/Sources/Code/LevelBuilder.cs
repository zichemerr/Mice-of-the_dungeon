using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    private GhostView _ghostView;
    private MouseSpawnerController _mouseSpawnerController;
    private BoxController _boxController;
    private PlayerInput _playerInput;
    
    public void Init(GhostView ghostView, MouseSpawnerController mouseSpawnerController, BoxController boxController, PlayerInput playerInput)
    {
        _ghostView = ghostView;
        _mouseSpawnerController = mouseSpawnerController;
        _boxController = boxController;
        _playerInput = playerInput;
    }

    public void BuildLevel(int levelIndex)
    {
        var entity = CMS.Get<LevelsEntity>();
        
        if (entity.Is<TagLevels>(out var tag))
        {
            List<BoxObject> boxes = new List<BoxObject>();
            List<WallObject> walls = new List<WallObject>();
            List<PointSpawnerObject> pointSpawner = new List<PointSpawnerObject>();
            
            var level = tag.Levels[levelIndex - 1];

            for (int i = 0; i < level.PointSpawnerObjectCount; i++)
                pointSpawner.Add(level.GetPointSpawnerObject(i));
            
            for (int i = 0; i < level.WallObjectCount; i++)
                walls.Add(level.GetWallObject(i));
            
            for (int i = 0; i < level.BoxObjectCount; i++)
                boxes.Add(level.GetBoxObject(i));

            foreach (var point in pointSpawner)
            {
                PointSpawner prefab = _mouseSpawnerController.SpawnPointSpawner(point.Position, point.Rotation);
                prefab.Init(point.SpawnCount);
            }
            
            foreach (var wall in walls)
            {
                GameObject prefab = Instantiate(D.Prefabs.LevelObjects.Wall);
                prefab.transform.position = wall.Position;
                prefab.transform.rotation = wall.Rotation;
                SpriteRenderer spriteRenderer = prefab.GetComponent<SpriteRenderer>();
                spriteRenderer.size = new Vector2(wall.Width, wall.Height);
            }
            
            foreach (var box in boxes)
                _boxController.SpawnBox(box);
            
            ImporterController importerController =Instantiate(D.Prefabs.Door.Importer);
            importerController.Init(level.ImporterCount, _ghostView, _playerInput);
            importerController.transform.position = level.Importer.Position;
            importerController.transform.rotation = level.Importer.Rotation;
            
            DoorController door = Instantiate(D.Prefabs.Door.Exit);
            door.Init(importerController);
            door.transform.position = level.Door.Position;
            door.transform.rotation = level.Door.Rotation;
        }
    }
}
