using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Sources.Code.Gameplay.PlayerSystem;
using Sources.Code.Gameplay.Sounds;
using UnityEngine;

namespace Sources.Code.Gameplay.MouseAltars
{
    public class MouseDeath : MonoBehaviour
    {
        [SerializeField] private MouseDeathView _mouseDeathView;
        
        private AudioSystem _audioSystem;

        public void Init(AudioSystem audioSystem)
        {
            _audioSystem = audioSystem;
        }
        
        public async UniTask DeathRoutine(Mouse mouse)
        {
            _audioSystem.PlaySound(_audioSystem.Sounds.Death);
            
            await _mouseDeathView.Hide();
            await UniTask.WaitForSeconds(0.05f);
            
            mouse.PlayDeathParticle();
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
