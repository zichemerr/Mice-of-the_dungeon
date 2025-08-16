using System;
using Cysharp.Threading.Tasks;
using Sources.Code.Gameplay.PlayerSystem;
using Sources.Code.Gameplay.Sounds;
using UnityEngine;

namespace Sources.Code.Gameplay.Door
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private DoorView _doorView;
        [SerializeField] private Collider2D _collider;
    
        private AudioSystem _audioSystem;
        private MouseAltars.MouseAltar _mouseAltar;
        private bool _isOpen;
    
        public event Action Entered;
    
        public void Init(MouseAltars.MouseAltar mouseAltar, DoorConfig config, AudioSystem audioSystem)
        {
            _doorView.Init(config.CapretText);
            _mouseAltar = mouseAltar;
            _mouseAltar.Impotred += OnImpotred;
            _isOpen = false;
            _audioSystem = audioSystem;
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
            _audioSystem.PlaySound(_audioSystem.Sounds.Door);
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