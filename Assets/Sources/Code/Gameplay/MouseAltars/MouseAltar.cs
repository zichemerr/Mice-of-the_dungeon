using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sources.Code.Gameplay.PlayerSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Code.Gameplay.MouseAltars
{
    public class MouseAltar : MonoBehaviour
    {
        [SerializeField] private MouseDeathBehaviour _mouseDeath;
        [SerializeField] private ImporterZone _zone;
        [SerializeField] private ImporterView _view;
        [FormerlySerializedAs("_ghostView")] [SerializeField] private GhostScreamerView ghostScreamerView;

        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private List<IImportable> _importables;
        private float lastTime;
        private float cooldownTime = 0.2f;
        private int _maxMouseCount;
        private bool _isDestroy;

        public event Action Impotred;
        public int MaxMouseCount => _maxMouseCount;

        public void Init(int maxMouseCount, PlayerInput playerInput)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
            _maxMouseCount = maxMouseCount;
            _importables = new List<IImportable>();
            _mouseDeath.Init(ghostScreamerView, playerInput);

            _isDestroy = false;
            _view.Init(_maxMouseCount);
        }

        private void OnEnable()
        {
            _zone.Entered += OnEntered;
            _zone.Exited += OnExited;
        }
        
        private void OnDisable()
        {
            _zone.Entered -= OnEntered;
            _zone.Exited -= OnExited;
        }

        private void OnEntered(IImportable importable)
        {
            if (_isDestroy)
                return;
            
            _importables.Add(importable); 
            _view.ShowValue(_importables.Count);

            if (Time.time - lastTime >= cooldownTime)
            {
                //Root.Audio.Play(Root.Sound.EnterZone, 0.5f);
                _view.Text.DOShakePosition(0.2f, 2f, 30).onComplete += () => _view.Text.localPosition = Vector2.zero;
                lastTime = Time.time;
            }

            if (_importables.Count == _maxMouseCount)
            {
                _isDestroy = true;
                DestoryRoutine().Forget();
            }
        }

        private async UniTaskVoid DestoryRoutine()
        {
            await _mouseDeath.DeathRoutine(_importables, _cancellationToken);
            Impotred?.Invoke();
        }

        private void OnExited(IImportable importable)
        {
            if (_importables.Count == _maxMouseCount)
                return;
            
            _importables.Remove(importable);
            _view.ShowValue(_importables.Count);
        }
    }
}