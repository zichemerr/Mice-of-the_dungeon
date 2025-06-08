using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private BuildMaterials _materials;
    
    private GhostView _ghostView;
    private MouseSpawnerController _mouseSpawnerController;
    private BoxController _boxController;
    private PlayerInput _playerInput;
    
    public void Init(GhostView ghostView, MouseSpawnerController mouseSpawnerController, BoxController boxController, PlayerInput playerInput)
    {
        _materials.Init();
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
            var level = tag.Levels[levelIndex - 1];
            
            ImporterController importer = _materials.GetImporter(level.Importer.Position, level.Importer.Rotation);
            DoorController door = _materials.GetDoor(level.Door.Position, level.Door.Rotation);
            
            door.Init(importer);
            importer.Init(level.ImporterCount, _ghostView, _playerInput);
            
            for (int i = 0; i < level.WallObjectCount; i++)
            {
                WallObject wallObject = level.GetWallObject(i);
                _materials.GetWall(wallObject.Position, wallObject.Rotation, wallObject.Width, wallObject.Height);
            }

            for (int i = 0; i < level.BoxObjectCount; i++)
            {
                BoxObject boxObject = level.GetBoxObject(i);
                Box box = _materials.GetBox(boxObject.Position, boxObject.Rotation);

                if (boxObject.SpawnerPointIsNull == false)
                {
                    PointSpawnerObject buildObject = boxObject.SpawnerPoint;
                    PointSpawner pointSpawner = _materials.GetPointSpawner(buildObject.Position, buildObject.Rotation);
                    _mouseSpawnerController.AddPointSpawner(pointSpawner);
                    pointSpawner.Init(buildObject.SpawnCount);
                    box.Init(pointSpawner);
                }
            }
        }
    }

    [ContextMenu("Clear")]
    public void Build()
    {
        _materials.ClearLevel();
        BuildLevel(1);
    }
    
    public void ClearLevel()
    {
        _materials.ClearLevel();
    }
}