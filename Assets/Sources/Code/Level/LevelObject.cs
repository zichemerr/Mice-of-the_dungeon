using System;
using UnityEngine;

public class LevelObject : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
