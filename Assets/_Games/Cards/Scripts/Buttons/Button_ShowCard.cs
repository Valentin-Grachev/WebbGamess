using UnityEngine;
using UnityEngine.UI;

namespace Cards
{
    public class Button_ShowCard : ButtonAction
    {
        [SerializeField] private CollectionCard _card;
        [SerializeField] private GameObject _oneCardSector;
        [SerializeField] private Image _image;
        [SerializeField] private GameObject _newLabel;

        protected override void OnClick()
        {
            _newLabel.SetActive(false);
            _oneCardSector.SetActive(true);
            _image.sprite = _card.cardData.sprite;
        }
    }


}


