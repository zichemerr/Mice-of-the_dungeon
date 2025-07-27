using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Sources.Code.Gameplay.Ghosts
{
    public class GhostAttackAnimation : MonoBehaviour
    {
        [SerializeField] private Transform _circle;

        private CancellationToken _cancellationToken;
        
        public void Init(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
        }
        
        public UniTask PlayAniamtion(float endValue, float duration)
        {
            return _circle.DOScale(endValue, duration).ToUniTask(cancellationToken: _cancellationToken);
        }
    }
}