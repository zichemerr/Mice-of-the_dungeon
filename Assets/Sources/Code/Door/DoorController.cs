using System;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private DoorView _doorView;
    
    private ImporterController _importer;
    private bool _isOpen = false;
    
    public void Init(ImporterController importer)
    {
        _importer = importer; 
        _importer.Impotred += OnImpotred;
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
            G.level.NextLevel();
        }
    }
}