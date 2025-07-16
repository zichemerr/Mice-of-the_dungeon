using System;
using Sources.Code.Gameplay.MouseAltar;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.Code.Gameplay.PlayerSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class Mouse : MonoBehaviour, IImportable
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private WalkAnimation _walkAnimation;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _speed;
        
        private Vector2 _target;
        private bool _isActive;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public event Action<Mouse> Destroyed;

        public void Init()
        {
            _isActive = true;
            _rigidbody.gravityScale = 0f;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
            _agent.speed = _speed;
        }

        private void FixedUpdate()
        {
            if (_isActive == false)
                return;

            if (_target == Vector2.zero)
                return;

            Vector2 direction = (_target - _rigidbody.position).normalized;

            _rigidbody.velocity = direction * _speed;

            if (_walkAnimation.IsPlaying == false)
            {
                _walkAnimation.Play();
            }

            if (Vector2.Distance(_rigidbody.position, _target) < 0.1f)
            {
                _rigidbody.velocity = Vector2.zero;
            }

            if (Vector2.Distance(_rigidbody.position, _target) < 1f)
            {
                if (_walkAnimation.IsPlaying)
                {
                    _walkAnimation.Stop();
                }
            }

            if (direction.x > 0)
                _spriteRenderer.flipX = false;
            else
                _spriteRenderer.flipX = true;
        }

        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }

        public void PlayDeadParticle()
        {
            if (this == null)
                return;

            //_particle.Play(Resources.Load<GameObject>("Dead"),transform.position);
        }
        
        public void Destroy()
        {
            Destroyed?.Invoke(this);
        }

        internal void SetDirection(Vector2 target)
        {
            _target = target;
        }
        
        public void Enable()
        {
            _isActive = true;
        }

        public void Disable()
        {
            _isActive = false;
        }
    }
}