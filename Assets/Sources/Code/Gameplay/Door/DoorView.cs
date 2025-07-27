using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Sources.Code.Gameplay.Door
{
    public class DoorView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _closedDoor;
        [SerializeField] private Sprite _openedDoor;
        [SerializeField] private TMP_Text _capret;
        
        private string _capretText;

        public void Init(string capretText)
        {
            _capretText = capretText;
            _spriteRenderer.sprite = _closedDoor;
            _spriteRenderer.color = Color.white;
        }
    
        public void DrawOpenedDoor()
        {
            _capret.text = _capretText;
            _spriteRenderer.DOColor(Color.black / 2, 0.1f).SetLink(gameObject);
            _spriteRenderer.sprite = _openedDoor;
            _spriteRenderer.DOColor(Color.black, 0.1f).SetLink(gameObject);
        }
    }
}