using UnityEngine;
using System.Collections;
using Newtonsoft.Json;

public class GameSaverLoader : SingletonBehaviour<GameSaverLoader>
{
    private const string SETTINGS_PROGRESS_KEY = "SettingsProgress";

    [SerializeField] private SettingsProgress _defaultSettingsProgress;

    private Coroutine _autoSaveCoroutine;

    public SettingsProgress SettingsProgress { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        var defaultSettingsProgressInJson = JsonConvert.SerializeObject(_defaultSettingsProgress);
        string settingsProgressInJson = PlayerPrefs.GetString(SETTINGS_PROGRESS_KEY, defaultSettingsProgressInJson);
        SettingsProgress = JsonConvert.DeserializeObject<SettingsProgress>(settingsProgressInJson);

        _autoSaveCoroutine = StartCoroutine(AutoSaveCoroutine());
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            MadeAutoSave();
        }
    }

    private void OnApplicationQuit()
    {
        MadeAutoSave();
    }

    private IEnumerator AutoSaveCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            MadeAutoSave();
        }
    }

    private void MadeAutoSave()
    {
        var settingsProgressInJson = JsonConvert.SerializeObject(SettingsProgress);
        PlayerPrefs.SetString(SETTINGS_PROGRESS_KEY, settingsProgressInJson);
        Debug.Log("SAVE");
    }
}