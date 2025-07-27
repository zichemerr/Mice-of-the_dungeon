using UnityEngine;

namespace Sources.Code.Configs
{
    [CreateAssetMenu(fileName = nameof(GhostConfig), menuName = "Configs/" + nameof(GhostConfig), order = 0)]
    public class GhostConfig : ScriptableObject
    {
        [SerializeField] private float _movementDuration;
        [SerializeField] private float _circleDuration;
        
        public float MovementDuration => _movementDuration;
        public float CircleDuration => _circleDuration;
    }
}