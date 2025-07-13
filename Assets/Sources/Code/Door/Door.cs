using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private DoorView _doorView;
    
    private MouseAltar _mouseAltar;
    private bool _isOpen;
    
    public event Action Entered;
    
    public void Init(MouseAltar mouseAltar)
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
        Debug.Log("Opened door");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isOpen == false)
            return;
        
        if (other.GetComponent<Mouse>())
        {
            Entered?.Invoke();
        }
    }
}