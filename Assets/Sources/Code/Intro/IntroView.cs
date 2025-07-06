using Cysharp.Threading.Tasks;
using DG.Tweening;
using Febucci.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroView : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private TextAnimator _textAnimator;
    [SerializeField] private TextAnimatorPlayer _player;
    [SerializeField] private Transform _transform;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;
    
    public void Enable()
    {
        _canvas.SetActive(true);
    }

    public void StartWrite()
    {
        _player.ShowText("GAME BY ZICHEMERR");
        _player.StartShowingText();
    }

    public void Shake()
    {
        _transform.DOShakePosition(0.2f, 15, 50);
    }

    public async UniTask HideText()
    {
        await _text.DOFade(0, 0.5f).ToUniTask();
    }

    public async UniTask HideBackground()
    {
        await _image.DOFade(0, 0.5f).ToUniTask();
    }

    public void WriteSound()
    {
        //G.audio.Play<WriteSound>();
    }
}