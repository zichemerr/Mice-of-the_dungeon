using System;
using Newtonsoft.Json;

[Serializable]
public class SettingsProgress
{
    [JsonProperty] public int Level = 1;
}