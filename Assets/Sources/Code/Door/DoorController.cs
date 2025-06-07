using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private DoorView _doorView;
    
    private ImporterController _importer;
    
    public void Init(ImporterController importer)
    {
        _importer = importer;
        _importer.Impotred += OnImpotred;
    }

    private void OnImpotred()
    {
        _doorView.DrawOpenedDoor();
        Debug.Log("Opened door");
    }
}