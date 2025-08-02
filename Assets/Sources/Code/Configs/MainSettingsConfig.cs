using UnityEngine;

namespace Sources.Code.Configs
{
    [CreateAssetMenu(fileName = nameof(MainSettingsConfig), menuName = "Configs/" + nameof(MainSettingsConfig), order = 0)]
    public class MainSettingsConfig : ScriptableObject
    {
        [SerializeField] private LevelsConfig _levelsConfig;
        [SerializeField] private GameEventScreenConfig _gameEventScreenConfig;
        [SerializeField] private SoundsConfig _soundsConfig;
        [SerializeField] private GhostConfig _ghostConfig;
        [SerializeField] private DoorConfig _doorConfig;
        [SerializeField] private ParticleConfig _particleConfig;

        public LevelsConfig LevelsConfig => _levelsConfig;
        public GameEventScreenConfig GameEventScreenConfig => _gameEventScreenConfig;
        public SoundsConfig SoundsConfig => _soundsConfig;
        public GhostConfig GhostConfig => _ghostConfig;
        public DoorConfig DoorConfig => _doorConfig;
        public ParticleConfig ParticleConfig => _particleConfig;
    }
}