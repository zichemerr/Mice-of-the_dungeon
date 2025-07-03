using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    
    private Main _main;
    
    public void Init(Main main)
    {
        _main = main;
    }

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnClickedPlayButton);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnClickedPlayButton);
    }

    private void OnClickedPlayButton()
    {
        _main.StartGame();
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
