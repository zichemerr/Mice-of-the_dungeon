using DG.Tweening;
using UnityEngine;

namespace Sources.Code.Configs
{
    [CreateAssetMenu(fileName = nameof(GameEventScreenConfig), menuName = "Configs/" + nameof(GameEventScreenConfig), order = 0)]
    public class GameEventScreenConfig : ScriptableObject
    {
        [SerializeField] private Ease _ease;
        [SerializeField] private float _duration;
        
        [Header("Victory")]
        [SerializeField] private Color _victoryImageColor;
        [SerializeField] private Color _victoryTextColor;
        [SerializeField] private string _victoryText;
        
        [Header("Defeat")]
        [SerializeField] private Color _defeatImageColor;
        [SerializeField] private Color _defeatTextColor;
        [SerializeField] private string _defeatText;
        
        public float Duration => _duration;
        public Ease Ease => _ease;
        public string VictoryText => _victoryText;
        public string DefeatText => _defeatText;
        public Color VictoryImageColor => _victoryImageColor;
        public Color DefeatImageColor => _defeatImageColor;
        public Color DefeatTextColor => _defeatTextColor;
        public Color VictoryTextColor => _victoryTextColor;
    }
}