using Cysharp.Threading.Tasks;
using Sources.Code.Gameplay.PlayerSystem;
using UnityEngine;

namespace Sources.Code.Gameplay.Ghosts
{
    public class GhostAttacker
    {
        private Transform _transform;
        private GhostAttackAnimation _ghostAttackAnimation;
        private float _radius;
        private float _circleDuration;
        
        public GhostAttacker(Transform transform, GhostAttackAnimation ghostAttackAnimation, float radius, float circleDuration)
        {
            _transform = transform;
            _ghostAttackAnimation = ghostAttackAnimation;
            _radius = radius;
            _circleDuration = circleDuration;
        }

        public async UniTask Attack()
        {
            await _ghostAttackAnimation.PlayAniamtion(1, _circleDuration);
            _ghostAttackAnimation.PlayAniamtion(0, _circleDuration);
            
            var colliders = Physics2D.OverlapCircleAll(_transform.position, _radius);

            foreach (var collider in colliders)
                if (collider.TryGetComponent(out Mouse mouse))
                    mouse.Destroy();
        }
    }
}