using System.Collections;
using UnityEngine;

namespace Sources.Code.Gameplay.PlayerSystem
{
    public class InputActivator
    {
        private PlayerInput _playerInput;
        private float _delay;

        public InputActivator(PlayerInput playerInput, float delay)
        {
            _playerInput = playerInput;
            _delay = delay;
        }
        
        public void Init(MonoBehaviour monoBehaviour)
        {
            _playerInput.Disable();
            
            monoBehaviour.StartCoroutine(Activate());
        }

        private IEnumerator Activate()
        {
            yield return new WaitForSeconds(_delay);
            _playerInput.Enable();
        }
    }
}
