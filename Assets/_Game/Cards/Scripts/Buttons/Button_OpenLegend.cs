using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdService;

namespace Cards
{
    public class Button_OpenLegend : ButtonClick
    {
        [SerializeField] private LegendCard _legendCard;

        protected override void OnClick()
        {
            RewardedAds.Show((callvack) =>
            {
                if (callvack == RewardedAds.ShowCallback.Success)
                {
                    PlayerPrefs.SetInt("Legend", 2);
                    _legendCard.UpdateCard();
                }
            });
        }
    }
}

