using UnityEngine;

namespace Sources.Code.Configs
{
    [CreateAssetMenu(fileName = nameof(ParticleConfig), menuName = "Configs/" + nameof(ParticleConfig), order = 0)]
    public class ParticleConfig : ScriptableObject
    {
        [SerializeField] private ParticleSystem _deadParticlePrefab;
        [SerializeField] private ParticleSystem _bornParticlePrefab;

        public ParticleSystem DeadParticlePrefab => _deadParticlePrefab;
        public ParticleSystem BornParticlePrefab => _bornParticlePrefab;
    }
}