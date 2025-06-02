using DG.Tweening;
using UnityEngine;

    public class PointAnimation : MonoBehaviour
    {
        [SerializeField] private PointAnimationContainer[] _containers;

        private Tween[] _tween;

        public void Init()
        {
            _tween = new Tween[_containers.Length];

            for (int i = 0; i < _containers.Length; i++)
            {
                _tween[i] = Play(_containers[i].Transfrom, _containers[i].Data);
            }
        }

        private Tween Play(Transform transform, PointAnimationData data)
        {
            return transform
                .DOShakePosition(data.Duration,
                data.Stren,
                data.Vibrato,
                data.Random)
                .SetLoops(-1);
        }

        public void Kill()
        {
            foreach (var tween in _tween)
            {
                tween.Kill();
            }
        }
    }