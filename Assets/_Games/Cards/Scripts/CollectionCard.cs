using UnityEngine;
using UnityEngine.UI;

namespace Cards
{
    public class CollectionCard : MonoBehaviour
    {
        [SerializeField] private CardData _card; public CardData cardData { get => _card; }
        [SerializeField] private Image _image;
        [SerializeField] private GameObject _newLabel;
        [SerializeField] private Button _showButton;

        private void OnEnable()
        {
            _newLabel.SetActive(false);
            _showButton.interactable = false;

            string key = _card.name;

            if (key != "Legend" && PlayerPrefs.HasKey(_card.name))
                OpenCard();
            else if (key == "Legend" && PlayerPrefs.HasKey(_card.name) && PlayerPrefs.GetInt(_card.name) == 2) 
                OpenLegend();
                
        }

        public void OpenLegend()
        {
            _image.sprite = _card.sprite;
            _showButton.interactable = true;
        }



        public void OpenCard()
        {
            _image.sprite = _card.sprite;
            _showButton.interactable = true;
            if (PlayerPrefs.GetInt(_card.name) == 1)
            {
                _newLabel.SetActive(true);
                PlayerPrefs.SetInt(_card.name, 2);
            }
        }


    }
}



