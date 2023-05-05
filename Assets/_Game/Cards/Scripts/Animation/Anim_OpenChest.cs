using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Cards
{
    public class Anim_OpenChest : MonoBehaviour
    {
        [SerializeField] private RectTransform _cardParty;
        [SerializeField] private Image _chestImage;
        [Space(10)]
        [SerializeField] private Sprite _openedChestSprite;
        [SerializeField] private Sprite _closedChestSprite;
        [Space(10)]
        [SerializeField] private Anim_Scale _collectionButtonAnim;
        [SerializeField] private Anim_Scale _openChestButtonAnim;
        [SerializeField] private Button _openChestButton;
        [SerializeField] private Button _collectionButton;

        private const float animDuration = 1f;

        private float _chestStartPositionY;
        private Vector2 _cardPartyStartPosition;



        private void Start()
        {
            _chestStartPositionY = _chestImage.rectTransform.anchoredPosition.y;
            _cardPartyStartPosition = _cardParty.anchoredPosition;
        }


        public void OpenChest()
        {
            CardGenerator.GenNewSample();
            CardParty.RestoreAll();
            CardParty.SetInteraction(false);
            ChestCard.cardsQuantity = 3;
            _collectionButtonAnim.Close();
            _openChestButtonAnim.Close();
            _openChestButton.interactable = false;
            _collectionButton.interactable = false;

            _chestImage.sprite = _openedChestSprite;
            _chestImage.SetNativeSize();
            _chestImage.rectTransform.DOAnchorPosY(_chestImage.rectTransform.anchoredPosition.y - 200, animDuration);
            _chestImage.DOColor(Color.clear, animDuration);

            _cardParty.DOAnchorPosY(_cardParty.anchoredPosition.y + 50, animDuration);
            _cardParty.DOScale(1f, animDuration).onComplete += () => 
            {
                CardParty.SetInteraction(true);
            };


        }

        public void ShowChest()
        {
            _chestImage.rectTransform.DOAnchorPosY(0f, animDuration);
            _chestImage.DOColor(Color.white, animDuration);
            _chestImage.sprite = _closedChestSprite;
            _chestImage.SetNativeSize();
            _openChestButton.interactable = true;
            _collectionButton.interactable = true;

            _cardParty.anchoredPosition = _cardPartyStartPosition;
            _cardParty.localScale = Vector3.zero;

            _collectionButtonAnim.Open();
            _openChestButtonAnim.Open();
        }




    }

}



