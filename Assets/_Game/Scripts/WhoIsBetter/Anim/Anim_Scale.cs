using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anim_Scale : MonoBehaviour
{
    [SerializeField] private bool _startOpened;
    [Space(10)]
    [SerializeField] private float _openDuration;
    [SerializeField] private Ease _openEase;
    [Space(10)]
    [SerializeField] private float _closeDuration;
    [SerializeField] private Ease _closeEase;


    private bool _opened;


    private void Awake()
    {
        _opened = _startOpened;
    }


    public void Open()
    {
        if (_opened) return;

        transform.DOScale(1f, _openDuration).SetEase(_openEase);
        _opened = true;
    }

    public void Close()
    {
        if (!_opened) return;

        transform.DOScale(0f, _closeDuration).SetEase(_closeEase);
        _opened = false;
    }


}
