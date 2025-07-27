using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sources.Code.Configs;
using UnityEngine;

namespace Sources.Code.Gameplay.Ghosts
{
    public class GhostMovement
    {
        private Transform _transform;
        private ObjQueue<Transform> _queue;
        private float _duration;
        private CancellationToken _cancellationToken;
        private GhostAttacker _ghostAttacker;
        
        public GhostMovement(Transform transform, Transform[] transformPoints, GhostConfig ghostConfig,
            CancellationToken cancellationToken, GhostAttacker ghostAttacker)
        {
            _transform = transform;
            _cancellationToken = cancellationToken;
            _duration = ghostConfig.MovementDuration;
            _queue = new ObjQueue<Transform>(transformPoints);
            _ghostAttacker = ghostAttacker;
        }
        
        public void Init()
        {
            Start().Forget();
        }

        private async UniTaskVoid Start()
        {
            while (true)
            {
                Transform point = _queue.Get();
                await _transform.DOMove(point.position, _duration)
                    .ToUniTask(cancellationToken: _cancellationToken);

                await _ghostAttacker.Attack();
            }
        }
    }
}