using System;
using Cysharp.Threading.Tasks;
using Sources.Code.Gameplay.PlayerSystem;
using UnityEngine;

namespace Sources.Code.Gameplay.Door
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private DoorView _doorView;
        [SerializeField] private Collider2D _collider;
    
        private MouseAltars.MouseAltar _mouseAltar;
        private bool _isOpen;
    
        public event Action Entered;
    
        public void Init(MouseAltars.MouseAltar mouseAltar)
        {
            _doorView.Init();
            _mouseAltar = mouseAltar;
            _mouseAltar.Impotred += OnImpotred;
            _isOpen = false;
        }

        private void OnDisable()
        {
            _mouseAltar.Impotred -= OnImpotred;
        }

        private void OnImpotred()
        {
            _isOpen = true;
            _doorView.DrawOpenedDoor();
            _collider.enabled = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isOpen == false)
                return;

            if (other.GetComponent<Mouse>() == false)
                return;
        
            Entered?.Invoke();
        }
    }
}