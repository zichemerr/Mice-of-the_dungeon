using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sources.Code.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Code.Gameplay.GameEvents
{
    public class GameEventScreen : MonoBehaviour
    {
        private const int EnabledEndValue = 1;
    
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _text;
    
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
    
        private Ease _ease;
        private float _duration;
        
        private string _victoryText;
        private Color _victoryColor;
        
        private string _defeatText;
        private Color _defeatColor;
    
        public void Init(GameEventScreenConfig config)
        {
            _ease = config.Ease;
            _duration = config.Duration;
            _defeatText = config.DefeatText;
            _victoryText = config.VictoryText;
            _victoryColor = config.VictoryImageColor;
            _defeatColor = config.DefeatImageColor;
            
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
        }

        private void OnDestroy()
        {
            _cancellationTokenSource.Cancel();
        }
    
        private async UniTaskVoid SetScreen(float duration, string text, Color color)
        {
            _text.text = text;
            _image.color = new Color(color.r, color.g, color.b, _image.color.a);
            
            await _canvasGroup.DOFade(duration, EnabledEndValue)
                .SetEase(_ease)
                .SetLink(gameObject)
                .ToUniTask(cancellationToken: _cancellationToken);
        }

        public void ShowVictory()
        {
            SetScreen(_duration, _victoryText, _victoryColor).Forget();
        }
        
        public void ShowDefeat()
        {
            SetScreen(_duration, _defeatText, _defeatColor).Forget();
        }
    }
}
