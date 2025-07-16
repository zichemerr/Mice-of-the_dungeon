using System;
using UnityEngine;

namespace Sources.Code.Gameplay.Spawner
{
    [Serializable]
    public class PointAnimationContainer
    {
        [field: SerializeField] public Transform Transfrom { get; private set; }
        [field: SerializeField] public PointAnimationData Data { get; private set; }
    }
}