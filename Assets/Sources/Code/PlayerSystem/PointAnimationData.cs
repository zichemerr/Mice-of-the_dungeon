using UnityEngine;

    [CreateAssetMenu(fileName = "PointAnimation")]
    public class PointAnimationData : ScriptableObject
    {
        [field: SerializeField] public float Duration { get; private set; }
        [field: SerializeField] public float Stren { get; private set; }
        [field: SerializeField] public float Random { get; private set; }
        [field: SerializeField] public int Vibrato { get; private set; }
    }