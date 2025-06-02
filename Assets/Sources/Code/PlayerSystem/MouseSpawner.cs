using UnityEngine;

public class MouseSpawner
{
    private Mouse _mousePrefab;

    public MouseSpawner(Mouse mousePrefab)
    {
        _mousePrefab = mousePrefab;
    }

    public Mouse Spawn()
    {
        Mouse mouse = GameObject.Instantiate(_mousePrefab);

        return mouse;
    }

    public Mouse[] Spawn(int count)
    {
        Mouse[] mouse = new Mouse[count];

        for (int i = 0; i < count; i++)
        {
            mouse[i] = GameObject.Instantiate(_mousePrefab);
        }

        return mouse;
    }
}