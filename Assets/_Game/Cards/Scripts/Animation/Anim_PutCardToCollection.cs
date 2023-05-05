using UnityEngine;
using DG.Tweening;

namespace Cards
{
    public class Anim_PutCardToCollection : MonoBehaviour
    {
        [SerializeField] private RectTransform _cardBlock;
        [SerializeField] private Anim_OpenChest _openChestAnim;

        private const float animDuration = 0.6f;


        public void Animate()
        {
            _cardBlock.DOAnchorPosY(_cardBlock.anchoredPosition.y - 190f, animDuration);

            _cardBlock.DOScale(0f, animDuration).onComplete += () =>
            {
                CardParty.SetInteraction(true);

                ChestCard.cardsQuantity--;
                if (ChestCard.cardsQuantity == 0)
                    _openChestAnim.ShowChest();
            };



        }
    }
}



