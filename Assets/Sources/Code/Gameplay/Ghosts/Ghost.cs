using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sources.Code.Configs;
using UnityEngine;

namespace Sources.Code.Gameplay.Ghosts
{
    public class Ghost : MonoBehaviour
    {
        [SerializeField] private Transform[] _movementPoints;
        
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private GhostMovement _movement;
        
        public void Init(GhostConfig ghostConfig)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
                
            _movement = new GhostMovement(transform, _movementPoints, ghostConfig, _cancellationToken);
            _movement.Init();
        }

        private void OnDestroy()
        {
            _cancellationTokenSource.Cancel();
        }
    }

    public class GhostMovement
    {
        private Transform _transform;
        private ObjQueue<Transform> _queue;
        private float _duration;
        private CancellationToken _cancellationToken;

        public GhostMovement(Transform transform, Transform[] transformPoints, GhostConfig ghostConfig,
            CancellationToken cancellationToken)
        {
            _transform = transform;
            _cancellationToken = cancellationToken;
            _duration = ghostConfig.MovementDuration;
            _queue = new ObjQueue<Transform>(transformPoints);
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
            }
        }
    }
    
    public class GhostAttacker : MonoBehaviour
    {
        
    }
    
    public class ObjQueue<T>
    {
        private Queue<T> _queue = new Queue<T>();
        private T[] _array;

        public ObjQueue(T[] array)
        {
            _array = array;
            InitQueue();
        }

        private void InitQueue()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                _queue.Enqueue(_array[i]);
            }
        }

        public T Get()
        {
            if (_queue.Count > 0)
            {
                return _queue.Dequeue();
            }

            InitQueue();
            return _queue.Dequeue();
        }
    }
}
