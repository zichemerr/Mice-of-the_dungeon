using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private List<Mouse> _movements;

    private MouseSpawner _mouseSpawner;

    public int MouseCount => _movements.Count;

    public void Init(MouseSpawner mouseSpawner)
    {
        _mouseSpawner = mouseSpawner;
        _mouseSpawner.Spawned += OnSpawned;
    }

    private void OnDisable()
    {
        _mouseSpawner.Spawned -= OnSpawned;

        foreach (var movement in _movements)
        {
            movement.Destroyed -= OnDestroyed;
        }
    }

    private void OnSpawned(Mouse mouse)
    {
        _movements.Add(mouse);
        mouse.Destroyed += OnDestroyed;
    }

    private void OnDestroyed(Mouse mouse)
    {
        if (mouse == null)
            return;

        _movements.Remove(mouse);
    }

    public void Move(Vector2 cursorPosition)
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(cursorPosition);

        foreach (Mouse movement in _movements)
        {
            movement.SetDirection(position);
        }
    }
}