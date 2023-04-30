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
    [SerializeField] private float _moveOffset;
    [SerializeField] private float _moveDuration;
    [SerializeField] private Ease _openEase;


    [HideInInspector] public CardData data;

    private RectTransform _rectTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void Active(bool shining, bool correct)
    {
        _arrow.SetActive(true);
        _correctLabel.gameObject.SetActive(true);

        if (correct) _correctLabel.sprite = _correctSprite;
        else _correctLabel.sprite = _incorrectSprite;

        _shine.SetActive(shining);
        _button.image.raycastTarget = false;
    }

    public void Deactive()
    {
        _button.image.raycastTarget = true;
        _arrow.SetActive(false);
        _correctLabel.gameObject.SetActive(false);
        _shine.SetActive(false);
    }

    public void RunAnimationForChangeCard()
    {
        DOTween.Sequence()
            .Append(_rectTransform.DOMoveX(_rectTransform.localPosition.x + _moveOffset, _moveDuration))
            .InsertCallback(0f, () => UpdateImage())
            .Append(_rectTransform.DOMoveX(_rectTransform.localPosition.x, _moveDuration));


    }

    private void UpdateImage()
    {
        _cardImage.sprite = data.sprite;
    }



}
