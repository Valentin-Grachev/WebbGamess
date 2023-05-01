using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Image _cardImage;
    [SerializeField] private GameObject _arrow;
    [SerializeField] private Image _correctLabel;
    [SerializeField] private GameObject _shine;
    [SerializeField] private Button _button;
    [Space(10)]
    [SerializeField] private Sprite _correctSprite;
    [SerializeField] private Sprite _incorrectSprite;

    [Header("Animation:")]
    [SerializeField] private float _moveDuration;
    [SerializeField] private Ease _openEase;


    [HideInInspector] public CardData data;

    private RectTransform _rectTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void Active(bool isTrueAnswer, bool selected)
    {
        _arrow.SetActive(true);
        
        if (selected)
        {
            _correctLabel.gameObject.SetActive(true);
            if (isTrueAnswer) _correctLabel.sprite = _correctSprite;
            else _correctLabel.sprite = _incorrectSprite;
        }

        _shine.SetActive(isTrueAnswer);
        _button.image.raycastTarget = false;
    }

    public void Deactive()
    {
        _button.image.raycastTarget = true;
        _arrow.SetActive(false);
        _correctLabel.gameObject.SetActive(false);
        _shine.SetActive(false);
    }

    public void ChangeCard()
    {
        float startPositionX = _rectTransform.localPosition.x;

        DOTween.Sequence()
            .Append(transform.DOScale(0f, _moveDuration).SetEase(_openEase))
            .InsertCallback(_moveDuration, () => UpdateImage())
            .Append(transform.DOScale(1f, _moveDuration).SetEase(_openEase));


    }

    public void UpdateImage()
    {
        _cardImage.sprite = data.sprite;
    }



}
