using System.Collections.Generic;
using System;
using UnityEngine;

    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        //[SerializeField] private GameEvents _losingGame;
        [SerializeField] private MouseSpawnerController _mouseSpawner;
        [SerializeField] private PlayerInput _playerInput;
        
        private List<Mouse> _mouses;

        public event Action MouseAlived;

        public void Init()
        {
            // _losingGame = Root.Main.Get<GameEvents>();

            _playerMovement.Init(_mouseSpawner);
            _mouseSpawner.Spawned += OnSpawned;
            _mouses = new List<Mouse>();

            for (int i = 0; i < _playerMovement.MouseCount; i++)
            {
                OnSpawned(_playerMovement.GetMouse(i));
            }
            
            _playerInput.Init(_playerMovement);
        }

        private void OnDisable()
        {
            _mouseSpawner.Spawned -= OnSpawned;

            foreach (var mouse in _mouses)
                mouse.Destroyed -= OnDestroyed;
        }

        private void OnSpawned(Mouse mouse)
        {
            mouse.Destroyed += OnDestroyed;
            _mouses.Add(mouse);
        }

        private void OnDestroyed(Mouse mouse)
        {
            _mouses.Remove(mouse);
            if (_playerMovement.MouseCount > 0)
            {
                MouseAlived?.Invoke();
                return;
            }

            //_losingGame.Lose();
        }

        public Mouse GetMouse()
        {
            Debug.Log(_mouses.Count);
            return _mouses[0];
        }
    }