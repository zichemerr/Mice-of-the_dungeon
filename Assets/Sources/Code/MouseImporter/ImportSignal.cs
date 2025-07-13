using UnityEngine;
using UnityEngine.Serialization;

public class ImportSignal : MonoBehaviour
    {
        [SerializeField] private PulseAnimation _pulse;
        [SerializeField] private MouseSpawner _spawner;
        [SerializeField] private MouseAltar _mouseAltar;
        
        private int _spawned;
        
        public void Init()
        {
            _spawner.Spawned += OnSpawned;
        }

        private void OnDisable()
        {
            _spawner.Spawned -= OnSpawned;
        }

        private void OnSpawned(Mouse mouse)
        {
            mouse.Destroyed += OnDestroyed;
            _spawned++;

            if (_spawned - 1 == _mouseAltar.MaxMouseCount)
            {
                _pulse.Play();
            }
        }

        private void OnDestroyed(Mouse mouse)
        {
            _spawned--;
            _pulse.Stop();
        }
    }