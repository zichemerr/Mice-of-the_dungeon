using DG.Tweening;
using UnityEngine;

namespace Sources.Code.Configs
{
    [CreateAssetMenu(fileName = nameof(GameEventScreenConfig), menuName = "Configs/" + nameof(GameEventScreenConfig), order = 0)]
    public class GameEventScreenConfig : ScriptableObject
    {
        [SerializeField] private Ease _ease;
        [SerializeField] private float _duration;
        [SerializeField] private string _victoryText;
        [SerializeField] private string _defeatText;
        
        public float Duration => _duration;
        public Ease Ease => _ease;
        public string VictoryText => _victoryText;
        public string DefeatText => _defeatText;
    }
}