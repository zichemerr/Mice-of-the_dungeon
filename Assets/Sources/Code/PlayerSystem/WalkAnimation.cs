using UnityEngine;
using DG.Tweening;
using System;

    public class WalkAnimation : MonoBehaviour
    {
        [SerializeField] private float pulseScale = 1.2f;
        [SerializeField] private float pulseDuration = 0.5f;
        [SerializeField] private Transform _transform;

        private int pulseLoops = -1;
        private Ease easeType = Ease.InOutSine;
        private Tween _tween;
        private Vector3 originalScale;

        public bool IsPlaying { get; private set; }

        public void Play()
        {
            if (_tween != null)
                return;

            originalScale = _transform.localScale;

            IsPlaying = true;
            _tween = _transform.DOScaleY(originalScale.y * pulseScale, pulseDuration)
                .SetEase(easeType)
                .SetLoops(pulseLoops, LoopType.Yoyo)
                .OnComplete(() => _transform.localScale = originalScale)
                .SetLink(gameObject);
        }

        public void Stop()
        {
            if (_tween == null)
                return;

            _tween.Kill();
            _tween = null;
            _transform.DOScaleY(originalScale.y, 0.5f).SetLink(gameObject).onComplete += () => IsPlaying = false;
        }
    }
