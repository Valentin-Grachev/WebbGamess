using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/Pairs")]
public class PairsData : ScriptableObject
{
    [SerializeField] private List<CardData> _cards;


    [System.Serializable]
    public class Pair
    {
        public CardData leftCard;
        public CardData rightCard;
        public int leftPercentage;
    }

    public List<Pair> pairs;


    [ContextMenu("Generate Pairs")]
    private void GeneratePairs()
    {
        pairs ??= new List<Pair>();
        pairs.Clear();

        for (int i = 0; i < _cards.Count; i++)
        {
            for (int j = i + 1; j < _cards.Count; j++)
            {
                Pair pair = new Pair();
                pair.leftCard = _cards[i];
                pair.rightCard = _cards[j];
                pair.leftPercentage = Random.Range(20, 81);
                if (pair.leftPercentage == 50) pair.leftPercentage += 1;
                pairs.Add(pair);
            }
        }
    }


    public Pair NewPair()
    {
        for (int i = 0; i < 1000; i++)
        {
            int randomIndex = Random.Range(0, pairs.Count);

            var pair = pairs[randomIndex];
            string pairKey = pair.leftCard.name + "_" + pair.rightCard.name;

            if (!PlayerPrefs.HasKey(pairKey)) return pair;
        }
        

        return null;
    }


    public static void SavePair(Pair pair)
    {
        string key = pair.leftCard.name + "_" + pair.rightCard.name;
        PlayerPrefs.SetInt(key, 1);
    }

}
