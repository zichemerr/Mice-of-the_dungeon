using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Code.Gameplay.PlayerSystem;

namespace Sources.Code.Gameplay.MouseAltars
{
    public class StartContentImport : MouseDeathBehaviour
    {
        private PlayerInput _playerInput;
        private GhostView _ghostView;

        public override void Init(GhostView ghostView, PlayerInput playerInput)
        {
            _playerInput = playerInput;
            _ghostView = ghostView;
        }

        public override async UniTask DeathRoutine(List<IImportable> importable, CancellationToken cancellationToken)
        {
            await UniTask.WaitForSeconds(0.5f, cancellationToken: cancellationToken);

            _ghostView.Enable();
            _playerInput.Disable();
            //AudioSystem.Const.Play(Root.Sound.Piano, 0.4f);
            
            await UniTask.WaitForSeconds(0.3f, cancellationToken: cancellationToken);
            
            await _ghostView.HideDispaly();
            await UniTask.WaitForSeconds(1f, cancellationToken: cancellationToken);

            _ghostView.Disable();

            foreach (var mouse in importable)
                mouse.Destroy();

            _playerInput.Enable();

            await _ghostView.ShowDispaly();
        }
    }
}