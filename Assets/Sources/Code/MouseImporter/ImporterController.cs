using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using DG.Tweening;

    public class ImporterController : MonoBehaviour
    {
        [SerializeField] private MouseDeathBehaviour _mouseDeath;
        [SerializeField] private ImporterZone _zone;
        [SerializeField] private ImporterView _view;
        [SerializeField] private int _importCount;

        private List<IImportable> _importables;

        private bool _isDestroy;
        private float lastTime;
        private float cooldownTime = 0.2f;

        public event Action Impotred;
        public int ImportCount => _importCount;

        public void Init(int imptCount, GhostView ghostView, PlayerInput playerInput)
        {
            _importCount = imptCount;
            _importables = new List<IImportable>();
            _mouseDeath.Init(ghostView, playerInput);

            _view.Init(_importCount);

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

            if (_importables.Count == _importCount)
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
            if (_importables.Count == _importCount)
                return;
            
            _importables.Remove(importable);
            _view.ShowValue(_importables.Count);
        }
    }