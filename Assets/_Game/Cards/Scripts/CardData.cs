using UnityEngine;

namespace Cards
{

    public enum Rarity { R1, R2, R3, R4, R5, R6 }


    [CreateAssetMenu(fileName = "R6_1", menuName = "Data/Cards/CardData")]
    public class CardData : ScriptableObject
    {
        public Sprite sprite;
        public Rarity rarity;
    }
}




