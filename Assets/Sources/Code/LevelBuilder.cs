using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private BuildMaterials _materials;

    private GhostView _ghostView;
    private MouseSpawnerController _mouseSpawnerController;
    private BoxController _boxController;
    private PlayerInput _playerInput;
    private Player _player;

    public void Init(GhostView ghostView, MouseSpawnerController mouseSpawnerController, BoxController boxController,
        PlayerInput playerInput, Player player)
    {
        _materials.Init();
        _ghostView = ghostView;
        _mouseSpawnerController = mouseSpawnerController;
        _boxController = boxController;
        _playerInput = playerInput;
        _player = player;
    }

    public void BuildLevel(int levelIndex)
    {
        var entity = CMS.Get<LevelsEntity>();

        if (entity.Is<TagLevels>(out var tag))
        {
            var level = tag.Levels[levelIndex];

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

            _player.GetMouse().transform.position = level.PlayerSpawnPoint.Position;
            Debug.Log(level.PlayerSpawnPoint.Position);
        }
    }

    public void ClearLevel()
    {
        _materials.ClearLevel();
    }
}