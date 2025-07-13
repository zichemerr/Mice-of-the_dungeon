#if UNITY_EDITOR
using UnityEngine;

[ExecuteInEditMode]
public class WallEditor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private BoxCollider2D _boxCollider;
    
    private void Update()
    {
        _boxCollider.size = new Vector2(_spriteRenderer.size.x, _spriteRenderer.size.y);
    }
}
#endif
