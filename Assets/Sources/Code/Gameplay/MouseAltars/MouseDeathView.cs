
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Code.Gameplay.MouseAltars
{
    public class MouseDeathView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        
        public async UniTask Show(float duration = 0)
        {
            await _image.DOFade(0, duration).SetLink(gameObject).ToUniTask();
        }

        public async UniTask Hide(float duration = 0)
        {
            await _image.DOFade(1, duration).SetLink(gameObject).ToUniTask();
        }
    }
}