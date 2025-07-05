using System;
using Newtonsoft.Json;
using UnityEngine.Serialization;

[Serializable]
//playerprogress
public class SettingsProgress
{
    [FormerlySerializedAs("Level")] [JsonProperty] public int LevelNumber = 1;
}