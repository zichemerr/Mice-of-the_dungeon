using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Main : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private IntroController _introController;
    [SerializeField] private MouseSpawnerController _mouseSpawnerController;
    
    private AudioSystem _audioSystem;
    
    private async void Start()
    {
        CMS.Init();
        _audioSystem = new AudioSystem();
        G.audio = _audioSystem;
        _player.Init();
        _mouseSpawnerController.Init();
        
#if (!UNITY_EDITOR)
            await _introController.StartIntro();
#endif
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