using UnityEngine;

namespace Sources.Code.Gameplay.Door
{
    public class DoorView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _closedDoor;
        [SerializeField] private Sprite _openedDoor;

        public void Init()
        {
            _spriteRenderer.sprite = _closedDoor;
            _spriteRenderer.color = Color.white;
        }
    
        public void DrawOpenedDoor()
        {
            _spriteRenderer.sprite = _openedDoor;
            _spriteRenderer.color = Color.black;
            Debug.Log("DrawOpenedDoorr");
        }
    }
}