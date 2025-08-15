using Sources.Code.Gameplay.MouseAltars;
using Sources.Code.Particles;
using UnityEngine;

namespace Sources.Code.Gameplay.PlayerSystem
{
    public class DeathMouse : MonoBehaviour, IImportable
    {
        private Particle _particle;
        
        public void Init(Particle particleSystem)
        {
            _particle = particleSystem;   
        }
        
        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void PlayDeathParticle()
        {
            _particle.Play(_particle.Config.DeadParticlePrefab, transform.position);
        }
    }
}
