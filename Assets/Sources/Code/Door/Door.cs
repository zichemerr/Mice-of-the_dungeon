using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private DoorView _doorView;
    [SerializeField] private Collider2D _collider;
    
    private MouseAltar _mouseAltar;
    private ScreenTansition _screenTansition;
    private bool _isOpen;
    
    public event Action Entered;
    
    public void Init(MouseAltar mouseAltar, ScreenTansition screenTansition)
    {
        _doorView.Init();
        _mouseAltar = mouseAltar;
        _screenTansition = screenTansition;
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
        
        StartTransition().Forget();
    }

    private async UniTask StartTransition()
    {
        await _screenTansition.Hide();
        Entered?.Invoke();
    }
}