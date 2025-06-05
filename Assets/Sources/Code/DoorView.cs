using UnityEngine;

public class DoorView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _openedDoor;
    [SerializeField] private Sprite _closedDoor;

    public void DrawOpenedDoor()
    {
        _openedDoor.sprite = _closedDoor;
        _openedDoor.color = Color.black;
    }
}