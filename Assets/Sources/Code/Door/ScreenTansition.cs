using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTansition : MonoBehaviour
{
    [SerializeField] private Image _image;

    private CancellationTokenSource _cancellationTokenSource;
    private CancellationToken _cancellationToken;
    
    public void Init()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _cancellationToken = _cancellationTokenSource.Token;
    }

    private void OnDestroy()
    {
        _cancellationTokenSource.Cancel();
    }

    public async UniTask Show()
    {
        await _image.DOFade(0, 1f).ToUniTask(cancellationToken: _cancellationToken);
    }

    public async UniTask Hide()
    {
        await _image.DOFade(1, 1f).ToUniTask(cancellationToken: _cancellationToken);
    }
}