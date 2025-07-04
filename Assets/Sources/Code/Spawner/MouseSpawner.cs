using System.Collections.Generic;
using UnityEngine;

public class MouseSpawner
{
    private Queue<Mouse> _mouses;
    private Mouse _prefab;
    private int _spawnCount;

    public MouseSpawner(Mouse mousePrefab, int spawnCount)
    {
        _mouses = new Queue<Mouse>();
        _prefab = mousePrefab;
        _spawnCount = spawnCount;
    }

    public void Init()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            Mouse mouse = GameObject.Instantiate(_prefab);
            _mouses.Enqueue(mouse);
        }
    }
    
    public Mouse GetMouse()
    {
        Mouse mouse = _mouses.Dequeue();
        mouse.Enable();
        
        return mouse;
    }

    public Mouse[] GetMouses(int count)
    {
        Mouse[] mouses = new Mouse[count];

        for (int i = 0; i < count; i++)
            mouses[i] = GetMouse();
        
        return mouses;
    }

    public void AddMouse(Mouse mouse)
    {
        mouse.gameObject.SetActive(false);
        _mouses.Enqueue(mouse);
    }
}