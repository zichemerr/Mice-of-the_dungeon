using System.Collections.Generic;
using UnityEngine;

namespace Sources.Code.Configs
{
    [CreateAssetMenu(fileName = nameof(LevelsConfig), menuName = "Configs/" + nameof(LevelsConfig), order = 0)]
    public class LevelsConfig : ScriptableObject
    {
        [SerializeField] private List<Level> _levels;

        public int LevelCount => _levels.Count;
    
        public Level GetLevelPrefabByIndex(int levelNumber)
        {
            return _levels[levelNumber];
        }
    }
}

