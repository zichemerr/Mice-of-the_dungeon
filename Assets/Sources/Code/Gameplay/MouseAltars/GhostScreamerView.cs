using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Code.Gameplay.MouseAltars
{
    public class GhostScreamerView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
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
            if (_cancellationTokenSource == null)
                return;
            
            _cancellationTokenSource.Cancel();
        }

        private async UniTask PlayAniamtion(int endValue, float duration)
        {
            await _image.DOFade(endValue, duration).ToUniTask(cancellationToken: _cancellationToken);
        }
    
        public void Enable()
        {
            _spriteRenderer.enabled = true;
        }
    
        public void Disable()
        {
            _spriteRenderer.enabled = false;
        }
    
        public async UniTask ShowDispaly(float duration = 0.5f)
        {
            await PlayAniamtion(0, duration);
        }
    
        public async UniTask HideDispaly(float duration = 0)
        {
            await PlayAniamtion(1, duration);
        }
    }
}