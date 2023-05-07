using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Cards
{
    public class RarityText : MonoBehaviour
    {

        [System.Serializable]
        public struct RarityInfo
        {
            public Rarity rarity;
            public Color color;
            public string text;
        }


        [SerializeField] private TextMeshProUGUI _text; public GameObject textObject { get => _text.gameObject; }
        [SerializeField] private List<RarityInfo> _rarityInfo;
        


        public void UpdateText(Rarity rarity)
        {
            foreach (var rarityInfo in _rarityInfo)
                if (rarity == rarityInfo.rarity)
                {
                    _text.text = rarityInfo.text;
                    _text.color = rarityInfo.color;
                }
        }


    }

}




