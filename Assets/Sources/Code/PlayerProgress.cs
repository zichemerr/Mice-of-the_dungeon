using System;
using Newtonsoft.Json;

[Serializable]
public class PlayerProgress
{
    [JsonProperty] public int LevelNumber = 1;
}