using UnityEngine;

namespace Sources.Code.Gameplay.PlayerSystem
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private InputActivator _inputActivator;
        private bool _isActive = true;

        public void Init(PlayerMovement playerMovement)
        {
            _inputActivator = new InputActivator(this, 0.5f);
            _inputActivator.Init(this);
            
            _playerMovement = playerMovement;
        }

        private Vector2 CursorPosition
        {
            get
            {
                Vector2 position = Input.mousePosition;
                return position;
            }
        }

        private void Update()
        {
            if (_isActive == false)
                return;

            if (Input.GetMouseButton(0))
            {
                _playerMovement.Move(CursorPosition);
            }
        }

        public void Disable()
        {
            _isActive = false;
        }

        public void Enable()
        {
            _isActive = true;
        }
    }
}