using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private IntroController _introController;
    [SerializeField] private MouseSpawnerController _mouseSpawnerController;
    [SerializeField] private ImporterController _importerController;
    
    private AudioSystem _audioSystem;
    
    private void Start()
    {
        CMS.Init();
        _audioSystem = new AudioSystem();
        G.audio = _audioSystem;
        _player.Init();
        _mouseSpawnerController.Init();
        _importerController.Init();
        
// #if (UNITY_EDITOR)
//         await UniTask.WaitForSeconds(0);
// #else
//         await _introController.StartIntro();
// #endif
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