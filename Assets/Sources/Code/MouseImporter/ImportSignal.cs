using UnityEngine;

    public class ImportSignal : MonoBehaviour
    {
        [SerializeField] private PulseAnimation _pulse;
        [SerializeField] private MouseSpawner _spawner;
        [SerializeField] private ImporterController _importer;
        
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

            if (_spawned - 1 == _importer.ImportCount)
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