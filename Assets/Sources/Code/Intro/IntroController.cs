using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    [SerializeField] private IntroView _view;

    public async UniTask StartIntro()
    {
        _view.Enable();
        await UniTask.WaitForSeconds(0.5f);
        _view.StartWrite();
        _view.Shake();
        
        await UniTask.WaitForSeconds(3);
        G.audio.Play<ClickSound>();
        _view.Shake();
        await _view.HideText();

        await UniTask.WaitForSeconds(0.5f);
        await _view.HideBackground();
    }
}