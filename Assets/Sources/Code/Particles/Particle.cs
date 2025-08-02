using Sources.Code.Configs;
using UnityEngine;

namespace Sources.Code.Particles
{
    public class Particle
    {
        private Transform _parent;
        
        public ParticleConfig Config { get; private set; }
        
        public Particle(ParticleConfig config, Transform parent)
        {
            Config = config;
            _parent = parent;
        }
        
        public void Play(ParticleSystem particleSystemPrefab, Vector2 position)
        {
            ParticleSystem instance = GameObject.Instantiate(particleSystemPrefab, _parent);
            instance.transform.position = position;
        }
    }
}
