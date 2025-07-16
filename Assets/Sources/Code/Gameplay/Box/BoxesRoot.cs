using UnityEngine;

namespace Sources.Code.Gameplay.Box
{
    public class BoxesRoot : MonoBehaviour
    {
        [SerializeField] private global::Sources.Code.Gameplay.Box.Box[] _boxes;

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
}
