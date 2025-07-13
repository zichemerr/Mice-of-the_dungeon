using UnityEngine;

public class BoxesRoot : MonoBehaviour
{
    [SerializeField] private Box[] _boxes;

    public void Init()
    {
        if (_boxes == null)
            return;
        
        foreach (var box in _boxes)
        {
            box.Init();
        }
    }
}
