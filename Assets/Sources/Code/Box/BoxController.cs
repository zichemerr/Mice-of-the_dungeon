using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private MouseSpawnerController _mouseSpawner;
    
    public void Init(MouseSpawnerController mouseSpawnerController)
    {
        _mouseSpawner = mouseSpawnerController;
    }

    public void SpawnBox(BoxObject boxData)
    {

    }
}
