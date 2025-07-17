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
        
        private Color _victoryImageColor;
        private Color _victoryTextColor;
        private string _victoryText;
        
        private Color _defeatImageColor;
        private Color _defeatTextColor;
        private string _defeatText;
        
        public void Init(GameEventScreenConfig config)
        {
            _ease = config.Ease;
            _duration = config.Duration;
            
            _victoryImageColor = config.VictoryImageColor;
            _victoryText = config.VictoryText;
            _victoryTextColor = config.VictoryTextColor;
            
            _defeatImageColor = config.DefeatImageColor;
            _defeatText = config.DefeatText;
            _defeatTextColor = config.DefeatTextColor;
            
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
        }

        private void OnDestroy()
        {
            _cancellationTokenSource.Cancel();
        }

        private Color SetColor(Color color, float fade)
        {
            return new Color(color.r, color.g, color.b, fade);
        }
        
        private async UniTask SetScreen(float duration, string text, Color imageColor, Color textColor)
        {
            _text.text = text;
            _text.color = SetColor(textColor, _text.color.a);
            _image.color = SetColor(imageColor, _image.color.a);
            
            await _canvasGroup.DOFade(duration, EnabledEndValue)
                .SetLink(gameObject)
                .ToUniTask(cancellationToken: _cancellationToken);
        }

        public void ShowVictory()
        {
            SetScreen(_duration, _victoryText, _victoryImageColor, _victoryTextColor).Forget();
        }
        
        public async UniTask ShowDefeat()
        {
            await SetScreen(_duration, _defeatText, _defeatImageColor, _defeatTextColor);
        }
    }
}
