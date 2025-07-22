using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Code.Gameplay.PlayerSystem;

namespace Sources.Code.Gameplay.MouseAltars
{
    public class StartContentImport : MouseDeathBehaviour
    {
        private PlayerInput _playerInput;
        private GhostScreamerView _ghostScreamerView;

        public override void Init(GhostScreamerView ghostScreamerView, PlayerInput playerInput)
        {
            _playerInput = playerInput;
            _ghostScreamerView = ghostScreamerView;
        }

        public override async UniTask DeathRoutine(List<IImportable> importable, CancellationToken cancellationToken)
        {
            await UniTask.WaitForSeconds(0.5f, cancellationToken: cancellationToken);

            _ghostScreamerView.Enable();
            _playerInput.Disable();
            //AudioSystem.Const.Play(Root.Sound.Piano, 0.4f);
            
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