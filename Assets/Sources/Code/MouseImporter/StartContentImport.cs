using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartContentImport : MouseDeathBehaviour
{
    private PlayerInput _playerInput;
    private GhostView _ghostView;

    public override void Init(GhostView ghostView, PlayerInput playerInput)
    {
        _playerInput = playerInput;
        _ghostView = ghostView;
    }

    public override IEnumerator DeathRoutine(List<IImportable> importable)
    {
        yield return new WaitForSeconds(0.5f);

        _ghostView.Enable();
        _playerInput.Disable();
        //AudioSystem.Const.Play(Root.Sound.Piano, 0.4f);

        yield return new WaitForSeconds(0.3f);

        yield return _ghostView.HideDispaly();
        yield return new WaitForSeconds(2f);

        _ghostView.Disable();

        foreach (var mouse in importable)
            mouse.Destroy();

        _playerInput.Enable();

        yield return _ghostView.ShowDispaly();
    }
}