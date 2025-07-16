using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.Code.UI
{
    public class ScreenSwitcher : MonoBehaviour
    {
        [SerializeField] private List<BaseScreen> _screensPrefabs = new List<BaseScreen>();

        private readonly Dictionary<Type, BaseScreen> _screenCache = new Dictionary<Type, BaseScreen>();
    
        private BaseScreen _currentScreen;
    
        public TScreen ShowScreen<TScreen>() where TScreen : BaseScreen
        {
            Type screenType = typeof(TScreen);

            if (_screenCache.TryGetValue(screenType, out var foundScreen))
            {
                _currentScreen.Disable();
                _currentScreen = foundScreen;
                _currentScreen.Enable();
            }
            else
            {
                BaseScreen prefab = _screensPrefabs.Find(x => x.GetType().FullName == screenType.FullName);
            
                var newScreen = Instantiate(prefab, transform);
                _currentScreen?.Disable();
                _currentScreen = newScreen;
                _screenCache[screenType] = newScreen;
            }
        
            return _currentScreen as TScreen;
        }

        public bool ScreenIsNull<TScreen>() where TScreen : BaseScreen
        {
            Type screenType = typeof(TScreen);

            if (_screenCache.TryGetValue(screenType, out var foundScreen))
                return false;
        
            return true;
        }
    }
}