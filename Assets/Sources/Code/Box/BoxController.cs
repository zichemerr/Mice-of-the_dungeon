using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private MouseSpawner _mouseSpawner;
    
    public void Init(MouseSpawner mouseSpawner)
    {
        _mouseSpawner = mouseSpawner;
    }
}
