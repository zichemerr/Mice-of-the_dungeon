using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Sources.Code.Gameplay.PlayerSystem;
using UnityEngine;

namespace Sources.Code.Gameplay.MouseAltars
{
    public class MouseDeath : MonoBehaviour
    {
        [SerializeField] private MouseDeathView _mouseDeathView;
    
        private float lastTime;
        private float cooldownTime = 0.2f;

        public async UniTask DeathRoutine(Mouse mouse)
        {
            if (Time.time - lastTime >= cooldownTime)
            {
                //Root.Audio.Play(Root.Sound.Scream, 0.3f);
                lastTime = Time.time;
            }

            await _mouseDeathView.Hide();
            await UniTask.WaitForSeconds(0.05f);
        
            mouse.PlayDeadParticle();
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
