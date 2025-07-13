using System;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    [SerializeField] private PointAnimation _pointAnimation;
    [SerializeField] private Transform _point; 
    [SerializeField] private int _spawnCount;

    public event Action<Vector2, int, PointSpawner> Entered;

    public void Init()
    {
        _pointAnimation.Init();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Mouse>())
        {
            Entered?.Invoke(_point.position, _spawnCount, this);
            gameObject.SetActive(false);
        }
    }
}