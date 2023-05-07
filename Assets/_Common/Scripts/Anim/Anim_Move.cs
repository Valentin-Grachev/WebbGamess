using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anim_Move : MonoBehaviour
{
    [SerializeField] private Vector2 _tweenOffset;
    [SerializeField] private bool _startOpened;
    [Space(10)]
    [SerializeField] private float _tweenSpeed;
    [SerializeField] private Ease _easeType;
    [Space(10)]
    [SerializeField] private List<Button> _nonInteractableButtons;

    


    private RectTransform rectTransform;
    private Vector2 _openedPosition;
    private Vector2 _closedPosition;

    private bool _opened;


    private void Awake()
    {
        _opened = _startOpened;
        rectTransform = transform.GetComponent<RectTransform>();

        if (_startOpened)
        {
            _openedPosition = rectTransform.anchoredPosition;
            _closedPosition = rectTransform.anchoredPosition + _tweenOffset;
        }
        else
        {
            _openedPosition = rectTransform.anchoredPosition + _tweenOffset;
            _closedPosition = rectTransform.anchoredPosition;
        }

    }


    public void Open()
    {
        if (_opened) return;

        var tween = rectTransform.DOAnchorPos(_openedPosition, _tweenSpeed).SetEase(_easeType);

        tween.onPlay += () =>
        {
            gameObject.SetActive(true);
            foreach (var button in _nonInteractableButtons)
                button.interactable = false;
        };


        tween.onComplete += () =>
        {
            foreach (var button in _nonInteractableButtons)
                button.interactable = true;
        };

        _opened = true;
    }

    public void Close()
    {
        if (!_opened) return;

        var tween = rectTransform.DOAnchorPos(_closedPosition, _tweenSpeed);

        tween.onPlay += () =>
        {
            foreach (var button in _nonInteractableButtons)
                button.interactable = false;
        };

        _opened = false;
    }


}
