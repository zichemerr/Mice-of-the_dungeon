using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene(1);
    }
}
