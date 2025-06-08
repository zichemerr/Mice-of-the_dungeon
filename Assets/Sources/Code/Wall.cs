using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    public SpriteRenderer SpriteRenderer => _spriteRenderer;
}
