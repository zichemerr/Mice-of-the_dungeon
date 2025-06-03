using UnityEngine;
using TMPro;

public class ImporterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private int _maxValue;

    public Transform Text => _text.transform;

    public void Init(int maxValue)
    {
        _maxValue = maxValue;
        ShowValue(0);
    }

    public void ShowValue(int value)
    {
        _text.text = $"{value}/{_maxValue}";
    }
}
