using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Sources.Code.Gameplay.PlayerSystem;
using Sources.Code.Gameplay.Sounds;
using Sources.Code.Particles;
using UnityEngine;

namespace Sources.Code.Gameplay.MouseAltars
{
    public class MouseDeath : MonoBehaviour
    {
        [SerializeField] private MouseDeathView _mouseDeathView;
    
        private Particle _particle;
        private AudioSystem _audioSystem;
        
        private float lastTime;
        private float cooldownTime = 0.2f;

        public void Init(Particle particle, AudioSystem audioSystem)
        {
            _particle = particle;
            _audioSystem = audioSystem;
        }
        
        public async UniTask DeathRoutine(Mouse mouse)
        {
            if (Time.time - lastTime >= cooldownTime)
            {
                _audioSystem.PlaySound(_audioSystem.Sounds.Death);
                lastTime = Time.time;
            }

            await _mouseDeathView.Hide();
            await UniTask.WaitForSeconds(0.05f);
        
            _particle.Play(_particle.Config.DeadParticlePrefab, mouse.Position);
            mouse.Destroy();
            await _mouseDeathView.Show(0.5f);
        }

        public async UniTask DeathRoutine(List<Mouse> importable)
        {
            await UniTask.WaitForSeconds(0.5f);

            foreach (var mouse in importable)
            {
                await DeathRoutine(mouse);
            }
        }
    }
}
