using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Cards
{
    public class CardParty : MonoBehaviour
    {
        [SerializeField] private Anim_OpenChest _anim;
        [SerializeField] private List<Button> _cardButtons;
        [SerializeField] private List<Anim_TurnCard> _cardsAnim;

        private static List<Button> cardButtons;
        private static List<Anim_TurnCard> cardsAnim;
        private static Transform thisTransform;

        private void Awake()
        {
            cardButtons = _cardButtons;
            cardsAnim = _cardsAnim;
            thisTransform = transform;
        }

        public static void SetInteraction(bool interaction)
        {
            foreach (var button in cardButtons)
                button.interactable = interaction;
        }

        public static void RestoreAll()
        {
            foreach (var cardAnim in cardsAnim)
                cardAnim.Restore();
        }



    }
}

