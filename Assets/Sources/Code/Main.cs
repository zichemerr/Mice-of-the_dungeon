using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private IntroController _introController;
    [SerializeField] private MouseSpawnerController _mouseSpawnerController;
    [SerializeField] private ImporterController _importerController;
    [SerializeField] private DoorController _doorController;
    [SerializeField] private BoxController _boxController;
    
    private AudioSystem _audioSystem;
    
    private void Start()
    {
        CMS.Init();
        _audioSystem = new AudioSystem();
        G.audio = _audioSystem;
        _player.Init();
        _boxController.Init(_mouseSpawnerController);
        _mouseSpawnerController.Init();
        _doorController.Init(_importerController);
        _importerController.Init();

        var entity = CMS.Get<LevelsEntity>();
        if (entity.Is<TagLevels>(out var tag))
        {
            List<BoxObject> boxes = new List<BoxObject>();
            List<WallObject> walls = new List<WallObject>();
            List<PointSpawnerObject> pointSpawner = new List<PointSpawnerObject>();
            
            var level = tag.Levels[0];

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
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

public static class G
{
    public static AudioSystem audio;
}