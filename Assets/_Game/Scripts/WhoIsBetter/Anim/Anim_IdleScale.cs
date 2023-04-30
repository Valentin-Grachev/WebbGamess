using DG.Tweening;
using UnityEngine;

public class Anim_IdleScale : MonoBehaviour
{
    [SerializeField] private float _toScale;
    [SerializeField] private float _loopTime;
    [SerializeField] private Ease _easeType;


    private void Start()
    {
        DOTween.Sequence()
            .Append(transform.DOScale(transform.localScale * _toScale, _loopTime).SetEase(_easeType))
            .Append(transform.DOScale(transform.localScale, _loopTime).SetEase(_easeType))
            .SetLoops(-1, LoopType.Restart);
    }


}
