using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    public enum CardPlace { Left, Center, Right }



    public class CardGenerator : MonoBehaviour
    {
        private static CardGenerator _instance;

        [SerializeField] private List<CardData> _cardsR6;
        [SerializeField] private List<CardData> _cardsR5;
        [SerializeField] private List<CardData> _cardsR4;
        [SerializeField] private List<CardData> _cardsR3;
        [SerializeField] private List<CardData> _cardsR2;
        [SerializeField] private List<CardData> _cardsR1;

        private static CardPlace newCardPlace;

        private static List<CardData> allCards;

        private static string previousCardKey;


        private void Awake()
        {
            _instance = this;
            allCards = GetAllCards();
        }


        public static void GenNewSample()
        {
            int rand = Random.Range(0, 3);
            if (rand == 0) newCardPlace = CardPlace.Left;
            else if (rand == 1) newCardPlace = CardPlace.Center;
            else newCardPlace = CardPlace.Right;

            string onlyNewkey = "OnlyNew";

            if (!PlayerPrefs.HasKey(onlyNewkey))
                PlayerPrefs.SetInt(onlyNewkey, 2);

            PlayerPrefs.SetInt(onlyNewkey, PlayerPrefs.GetInt(onlyNewkey) - 1);
        }

        public static CardData GetCard(CardPlace cardPlace)
        {
            if (PlayerPrefs.GetInt("OnlyNew") >= 0)
                return GetNewCard();

            else if (cardPlace == newCardPlace) 
                return GetNewCard();

            return GetExistCard();
        }


        private static CardData GetNewCard()
        {
            CardData card = null;

            for (int i = 0; i < 500; i++)
            {
                card = SelectRandom(allCards);
                if (!PlayerPrefs.HasKey(card.name)) return card;
            }

            return _instance._cardsR1[0];
        }

        private static CardData GetExistCard()
        {
            CardData card = null;

            for (int i = 0; i < 500; i++)
            {
                card = SelectRandom(allCards);
                bool samePrevious = previousCardKey == card.name;
                previousCardKey = card.name;

                if (PlayerPrefs.HasKey(card.name) && !samePrevious) return card;
            }

            return _instance._cardsR1[0];
        }


        public static List<CardData> GetAllCards()
        {
            List<CardData> cards = new List<CardData>();
            foreach (var card in _instance._cardsR6) cards.Add(card);
            foreach (var card in _instance._cardsR5) cards.Add(card);
            foreach (var card in _instance._cardsR4) cards.Add(card);
            foreach (var card in _instance._cardsR3) cards.Add(card);
            foreach (var card in _instance._cardsR2) cards.Add(card);
            foreach (var card in _instance._cardsR1) cards.Add(card);
            return cards;
        }


        private static CardData SelectRandom(List<CardData> cards)
        {
            int rand = Random.Range(0, cards.Count);
            return cards[rand];
        }



    }

}



