using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sources.Code.Gameplay.PlayerSystem;
using Sources.Code.Gameplay.Sounds;
using UnityEngine;

namespace Sources.Code.Gameplay.MouseAltars
{
    public class MouseAltar : MonoBehaviour
    {
        [SerializeField] private MouseDeathBehaviour _mouseDeath;
        [SerializeField] private MouseAltarZone _zone;
        [SerializeField] private MouseAltarView _view;
        [SerializeField] private MouseAltarSignal _signal;

        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private AudioSystem _audioSystem;
        private List<IImportable> _importables;
        private float lastTime;
        private float cooldownTime = 0.2f;
        private int _maxMouseCount;
        private bool _isDestroy;

        public event Action Impotred;
        public int MaxMouseCount => _maxMouseCount;

        public void Init(GhostScreamerView ghostScreamerView, int maxMouseCount, PlayerInput playerInput, AudioSystem audioSystem)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
            _maxMouseCount = maxMouseCount;
            _importables = new List<IImportable>();
            _mouseDeath.Init(ghostScreamerView, playerInput, audioSystem);
            _signal.Init();

            _isDestroy = false;
            _view.Init(_maxMouseCount);
            _audioSystem = audioSystem;
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
                _audioSystem.PlaySound(_audioSystem.Sounds.Enter);
                _view.Text.DOShakePosition(0.2f, 5f, 40).onComplete += () => _view.Text.localPosition = Vector2.zero;
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