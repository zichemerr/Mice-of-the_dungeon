using System.Collections.Generic;
using Cysharp.Threading.Tasks;
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
            var level = tag.Levels[0];
            
            for (int i = 0; i < level.BoxObjectCount; i++)
                boxes.Add(level.GetBoxObject(i));
            
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