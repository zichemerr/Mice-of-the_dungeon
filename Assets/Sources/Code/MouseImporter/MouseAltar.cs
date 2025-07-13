using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using DG.Tweening;

    public class MouseAltar : MonoBehaviour
    {
        [SerializeField] private MouseDeathBehaviour _mouseDeath;
        [SerializeField] private ImporterZone _zone;
        [SerializeField] private ImporterView _view;
        [SerializeField] private GhostView _ghostView;
        
        private List<IImportable> _importables;
        private float lastTime;
        private float cooldownTime = 0.2f;
        private int _maxMouseCount;
        private bool _isDestroy;

        public event Action Impotred;
        public int MaxMouseCount => _maxMouseCount;

        public void Init(int maxMouseCount, PlayerInput playerInput)
        {
            _maxMouseCount = maxMouseCount;
            _importables = new List<IImportable>();
            _mouseDeath.Init(_ghostView, playerInput);

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

            Debug.Log($"OnEntered {_importables.Count}");
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
                StartCoroutine(DestoryRoutine());
            }
        }

        private IEnumerator DestoryRoutine()
        {
            yield return _mouseDeath.DeathRoutine(_importables);
            Impotred?.Invoke();
            Debug.Log("Imped");
        }

        private void OnExited(IImportable importable)
        {
            if (_importables.Count == _maxMouseCount)
                return;
            
            _importables.Remove(importable);
            _view.ShowValue(_importables.Count);
        }
    }