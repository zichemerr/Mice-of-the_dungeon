using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Code.Gameplay.PlayerSystem;
using Sources.Code.Gameplay.Sounds;

namespace Sources.Code.Gameplay.MouseAltars
{
    public class StartContentImport : MouseDeathBehaviour
    {
        private PlayerInput _playerInput;
        private GhostScreamerView _ghostScreamerView;
        private AudioSystem _audioSystem;

        public override void Init(GhostScreamerView ghostScreamerView, PlayerInput playerInput, AudioSystem audioSystem)
        {
            _playerInput = playerInput;
            _ghostScreamerView = ghostScreamerView;
            _audioSystem = audioSystem;
        }

        public override async UniTask DeathRoutine(List<IImportable> importable, CancellationToken cancellationToken)
        {
            await UniTask.WaitForSeconds(0.5f, cancellationToken: cancellationToken);

            _ghostScreamerView.Enable();
            _playerInput.Disable();
            _audioSystem.PlaySound(_audioSystem.Sounds.Scream);
            
            await UniTask.WaitForSeconds(0.3f, cancellationToken: cancellationToken);
            
            await _ghostScreamerView.HideDispaly();
            await UniTask.WaitForSeconds(1f, cancellationToken: cancellationToken);

            _ghostScreamerView.Disable();

            foreach (var mouse in importable)
                mouse.Destroy();

            _playerInput.Enable();

            await _ghostScreamerView.ShowDispaly();
        }
    }
}