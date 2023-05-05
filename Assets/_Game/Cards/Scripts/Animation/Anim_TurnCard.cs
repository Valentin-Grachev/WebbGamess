using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Cards
{
    public class Anim_TurnCard : MonoBehaviour
    {
        [SerializeField] private CardPlace _cardPlace;
        [Space(10)]
        [SerializeField] private ChestCard _chestCard;
        [SerializeField] private Image _image;
        [SerializeField] private RarityText _rarityText;
        [SerializeField] private RectTransform _frontCell;
        [SerializeField] private RectTransform _partyCell;
        [Space(10)]
        [SerializeField] private GameObject _okButton;
        [SerializeField] private GameObject _takeButton;


        private RectTransform _rectTransform;
        private Vector2 _startPosition;
        private Sprite _closedCardSprite;

        private const float animDuration = 0.25f;
        private const float openedCardScale = 1.6f; 


        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _startPosition = _rectTransform.localPosition;
            _closedCardSprite = _image.sprite;
        }



        public void Open()
        {
            _chestCard.currentCard = CardGenerator.GetCard(_cardPlace);

            _rarityText.UpdateText(_chestCard.currentCard.rarity);

            _frontCell.anchoredPosition = _rectTransform.anchoredPosition;
            _frontCell.transform.localScale = Vector3.one;

            transform.SetParent(_frontCell);


            _frontCell.DOAnchorPosX(0, 2*animDuration);
            _frontCell.DOScale(openedCardScale, animDuration);

            DOTween.Sequence()
                .Append(_frontCell.DOScaleX(0, animDuration).SetEase(Ease.Linear))
                .AppendCallback(() =>
                {
                    _image.sprite = _chestCard.currentCard.sprite;
                    _rarityText.textObject.SetActive(true);

                    if (PlayerPrefs.HasKey(_chestCard.currentCard.name)) _okButton.SetActive(true);
                    else _takeButton.SetActive(true);
                })
                .Append(_frontCell.DOScale(openedCardScale, animDuration).SetEase(Ease.Linear));
        }


        public void Restore()
        {
            transform.SetParent(_partyCell);
            transform.localScale = Vector3.one;
            _rectTransform.anchoredPosition = _startPosition;
            _image.sprite = _closedCardSprite;

            _rarityText.textObject.SetActive(false);
            _okButton.SetActive(false);
            _takeButton.SetActive(false);
        }




    }
}



