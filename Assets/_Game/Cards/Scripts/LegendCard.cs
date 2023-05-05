using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    public class LegendCard : MonoBehaviour
    {
        [SerializeField] private CollectionCard _card;
        [SerializeField] private GameObject _adButton;


        private void OnEnable()
        {
            UpdateCard();
        }

        public void UpdateCard()
        {
            _adButton.SetActive(false);

            if (!PlayerPrefs.HasKey("Legend"))
            {
                bool unlocked = true;

                foreach (var card in CardGenerator.GetAllCards())
                    if (!PlayerPrefs.HasKey(card.name))
                    {
                        unlocked = false;
                        break;
                    }

                if (unlocked)
                {
                    PlayerPrefs.SetInt("Legend", 1);
                    _adButton.SetActive(true);
                }
            }
            else if (PlayerPrefs.GetInt("Legend") == 1)
            {
                _adButton.SetActive(true);
            }
            else
            {
                _card.OpenLegend();
            }


        }



    }
}



