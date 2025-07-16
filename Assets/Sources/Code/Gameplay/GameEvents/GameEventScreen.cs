using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sources.Code.Configs;
using TMPro;
using UnityEngine;

namespace Sources.Code.Gameplay.GameEvents
{
    public class GameEventScreen : MonoBehaviour
    {
        private const int EnabledEndValue = 1;
    
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TMP_Text _text;
    
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
    
        private Ease _ease;
        private float _duration;
        private string _victoryText;
        private string _defeatText;
    
        public void Init(GameEventScreenConfig config)
        {
            _ease = config.Ease;
            _duration = config.Duration;
            _defeatText = config.DefeatText;
            _victoryText = config.VictoryText;
            
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
        }

        private void OnDestroy()
        {
            _cancellationTokenSource.Cancel();
        }
    
        private async UniTaskVoid SetScreen(float duration, string text)
        {
            _text.text = text;
            
            await _canvasGroup.DOFade(duration, EnabledEndValue)
                .SetEase(_ease)
                .SetLink(gameObject)
                .ToUniTask(cancellationToken: _cancellationToken);
        }

        public void ShowVictory()
        {
            SetScreen(_duration, _victoryText).Forget();
        }
        
        public void ShowDefeat()
        {
            SetScreen(_duration, _defeatText).Forget();
        }
    }
}
