using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Code.Gameplay.MouseAltar
{
    public class GhostView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Image _image;
    
        private YieldInstruction PlayAniamtion(int endValue, float duration)
        {
            return _image.DOFade(endValue, duration).WaitForCompletion();
        }
    
        public void Enable()
        {
            _spriteRenderer.enabled = true;
        }
    
        public void Disable()
        {
            _spriteRenderer.enabled = false;
        }
    
        public YieldInstruction ShowDispaly(float duration = 0.5f)
        {
            return PlayAniamtion(0, duration);
        }
    
        public YieldInstruction HideDispaly(float duration = 0)
        {
            return PlayAniamtion(1, duration);
        }
    }
}