using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Code.Configs;
using Sources.Code.Gameplay.MouseAltars;
using Sources.Code.Gameplay.PlayerSystem;
using UnityEngine;

namespace Sources.Code.Gameplay.Ghosts
{
    public class Ghost : MonoBehaviour
    {
        [SerializeField] private MouseDeath _mouseDeath;
        [SerializeField] private GhostAttackAnimation _ghostAttackAnimation;
        [SerializeField] private Transform[] _movementPoints;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private float _radius;
        
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private GhostMovement _movement;
        private GhostAttacker _attacker;
        
        public void Init(GhostConfig ghostConfig)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
                
            _ghostAttackAnimation.Init(_cancellationToken);
            
            _attacker = new GhostAttacker(_attackPoint, _ghostAttackAnimation, _radius, ghostConfig.CircleDuration);
            _movement = new GhostMovement(transform, _movementPoints, ghostConfig, _cancellationToken, _attacker);
            _movement.Init();
        }

        private void OnDestroy()
        {
            _cancellationTokenSource.Cancel();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Mouse mouse))
            {
                _mouseDeath.DeathRoutine(mouse).Forget();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_attackPoint.position, _radius);
        }
    }
}
