using System.Collections.Generic;
using UnityEngine;

public class MouseSpawner
{
    private Queue<Mouse> _mouses;
    private Mouse _prefab;

    public MouseSpawner(Mouse mousePrefab)
    {
        _mouses = new Queue<Mouse>();
        _prefab = mousePrefab;
    }

    public void Init(CMSEntity cmsEntity)
    {
        if (cmsEntity.Is<TagSpawnerCount>(out var tag))
        {
            for (int i = 0; i < tag.Count; i++)
            {
                Mouse mouse = GameObject.Instantiate(_prefab);
                _mouses.Enqueue(mouse);
            }
        }
    }
    
    public Mouse GetMouse()
    {
        Mouse mouse = _mouses.Dequeue();
        mouse.gameObject.SetActive(true);
        
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