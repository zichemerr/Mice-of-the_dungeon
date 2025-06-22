using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private BoxCollider2D _collider;
    
    public SpriteRenderer SpriteRenderer => _spriteRenderer;

    public void SetCollider()
    {
        _collider.size = new Vector2(_spriteRenderer.size.x, _spriteRenderer.size.y);
    }
}
